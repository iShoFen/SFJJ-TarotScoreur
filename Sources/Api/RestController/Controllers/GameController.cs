using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Games;
using Model.Players;
using Model.Rules;
using RestController.DTOs.Extensions;
using RestController.DTOs.Games;
using RestController.Filter;

namespace RestController.Controllers;

[Route("game/")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly Manager _manager;

    public GameController(Manager manager)
    {
        _manager = manager;
    }

    // GAMES

    [HttpGet]
    public async Task<ActionResult> GetGames([FromQuery] PaginationFilter paginationFilter)
    {
        var games = await _manager.GetGames(paginationFilter.Page, paginationFilter.Count);
        return Ok(games.Select(x => x.ToGameDTO()).ToList());
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetGame))]
    public async Task<ActionResult> GetGame(ulong id)
    {
        var game = await _manager.GetGameById(id);
        if (game == null) return NotFound();
        return Ok(game.ToGameDetailDTO());
    }

    // USER

    [HttpGet("{id}/user/")]
    public async Task<ActionResult> GetUsersByGameId(ulong id)
    {
        var game = await _manager.GetGameById(id);
        if (game == null) return NotFound();
        var users = game.Players;
        return Ok(users.Select(x => x.PlayerToDTO()).ToList());
    }

    [HttpGet("{gameId}/user/{userId}")]
    public async Task<ActionResult> GetUserByGameId(ulong gameId, ulong userId)
    {
        var game = await _manager.GetGameById(gameId);
        if (game == null) return NotFound();
        var user = game.Players.SingleOrDefault(x => x.Id == userId);
        if (user == null) return NotFound();
        return Ok(user.PlayerToDTO());
    }

    [HttpPost]
    public async Task<ActionResult> PostGame(GameInsertRequest request)
    {
        if (request.Users.Count == 0) return BadRequest();

        var users = new List<Player>();
        foreach (var userId in request.Users)
        {
            var user = await _manager.GetUserById(userId);
            if (user is null)
            {
                return BadRequest($"The user with id {userId} does not exist");
            }

            users.Add(user);
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            return BadRequest($"The rules {request.Rules} does not correspond to any rules");
        }

        var game = (await _manager.InsertGame(request.Name, rules, request.StartDate, users.ToArray()))!;

        return CreatedAtAction(
            nameof(GetGame),
            new { id = game.Id },
            game.ToGameDetailDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(ulong id, GameUpdateRequest request)
    {
        if (id != request.Id) return BadRequest($"The url id {id} does not correspond to the body id {request.Id}");

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            return BadRequest($"The rules {request.Rules} does not correspond to any rules");
        }

        var game = new Game(
            request.Id,
            request.Name,
            rules,
            request.StartDate,
            request.EndDate
        );

        var gameUpdated = await _manager.UpdateGame(game);
        if (gameUpdated is null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(ulong id)
    {
        var deleted = await _manager.DeleteGame(id);

        if (!deleted) return NotFound();

        return NoContent();
    }
}
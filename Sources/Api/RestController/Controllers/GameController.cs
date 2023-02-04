using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Rules;
using RestController.DTOs;
using RestController.DTOs.Extensions;
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
    public async Task<ActionResult> PostGame(GameDTOPostRequest gameDtoPostRequest)
    {
        if (gameDtoPostRequest.Users.Count == 0) return BadRequest();
        var players = gameDtoPostRequest.Users.Select(x => _manager.GetPlayerById(x).Result).ToList();
        if (!players.TrueForAll(player => player != null)) return BadRequest();
        var game = await _manager.InsertGame(gameDtoPostRequest.Name, RulesFactory.Create(gameDtoPostRequest.Rules), gameDtoPostRequest.StartDate, players.ToArray()) ;

        return CreatedAtAction(
            nameof(GetGame),
            new { id = game.Id },
            game.ToGameDetailDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(ulong id, GameDetailDTO gameDetailDto)
    {
        if (id != gameDetailDto.Id) return BadRequest();
        var game = await _manager.UpdateGame(gameDetailDto.ToGameModel());
        if (game is null) return NotFound();
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
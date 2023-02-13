using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Games;
using Model.Players;
using Model.Rules;
using RestController.DTOs.Extensions;
using RestController.DTOs.Games;
using RestController.Filter;

namespace RestController.Controllers;

/// <summary>
/// The games controller for REST API
/// </summary>
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<GamesController> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public GamesController(Manager manager, ILogger<GamesController> logger)
    {
        _manager = manager;
        _logger = logger;
        
        _logger.LogInformation("GamesController created");
    }
    
    /// <summary>
    /// Get all games with pagination
    /// </summary>
    /// <param name="paginationFilter">The pagination</param>
    /// <returns>The list of games</returns>
    [HttpGet]
    public async Task<ActionResult> GetGames([FromQuery] PaginationFilter paginationFilter)
    {
        var games = (await _manager.GetGames(paginationFilter.Page, paginationFilter.Count)).ToList();
        _logger.LogInformation("{GamesCount} games from {Page} page with {PageSize} size retrieved", 
            games.Count,
            paginationFilter.Page,
            paginationFilter.Count
        );
        
        return Ok(games.Select(x => x.ToGameDTO()).ToList());
    }

    /// <summary>
    /// Get a game by id
    /// </summary>
    /// <param name="id">The id of the game</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ActionName(nameof(GetGame))]
    public async Task<ActionResult> GetGame(ulong id)
    {
        var game = await _manager.GetGameById(id);
        if (game == null)
        {
            _logger.LogWarning("Game with id {GameId} not found", id);
            return NotFound();
        }
        _logger.LogInformation("Game with id {GameId} retrieved", id);

        return Ok(game.ToGameDetailDTO());
    }
    
    /// <summary>
    /// Create user for a game
    /// </summary>
    /// <param name="id">The id of the game</param>
    /// <returns>The list of users for the game</returns>
    [HttpGet("{id}/users")]
    public async Task<ActionResult> GetUsersByGameId(ulong id)
    {
        var game = await _manager.GetGameById(id);
        if (game == null)
        {
            _logger.LogWarning("Game with id {GameId} not found", id);
            return NotFound();
        }
        var users = game.Players;
        _logger.LogInformation("{UsersCount} users from game with id {GameId} retrieved", users.Count, id);
        
        return Ok(users.Select(x => x.PlayerToDTO()).ToList());
    }

    /// <summary>
    /// Get a user by id for a game
    /// </summary>
    /// <param name="gameId">The id of the game</param>
    /// <param name="userId">The id of the user</param>
    /// <returns>The user</returns>
    [HttpGet("{gameId}/users/{userId}")]
    public async Task<ActionResult> GetUserByGameId(ulong gameId, ulong userId)
    {
        var game = await _manager.GetGameById(gameId);
        if (game == null)
        {
            _logger.LogWarning("Game with id {GameId} not found", gameId);
            return NotFound();
        }
        var user = game.Players.SingleOrDefault(x => x.Id == userId);
        if (user == null)
        {
            _logger.LogWarning("User with id {UserId} not found in game with id {GameId}", userId, gameId);
            return NotFound();
        }
        _logger.LogInformation("User with id {UserId} from game with id {GameId} retrieved", userId, gameId);
        
        return Ok(user.PlayerToDTO());
    }

    /// <summary>
    /// Create a game
    /// </summary>
    /// <param name="request">The Game to insert</param>
    /// <returns>The game inserted</returns>
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
                _logger.LogWarning("User with id {UserId} not found", userId);
                return BadRequest($"The user with id {userId} does not exist");
            }

            users.Add(user);
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.LogWarning("Rules {Rules} not found", request.Rules);
            return BadRequest($"The rules {request.Rules} does not correspond to any rules");
        }

        var game = (await _manager.InsertGame(request.Name, rules, request.StartDate, users.ToArray()))!;
        _logger.LogInformation("Game with id {GameId} inserted", game.Id);

        return CreatedAtAction(
            nameof(GetGame),
            new { id = game.Id },
            game.ToGameDetailDTO());
    }

    /// <summary>
    /// Update a game
    /// </summary>
    /// <param name="id">The id of the game</param>
    /// <param name="request">The game to update</param>
    /// <returns>The game updated</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(ulong id, GameUpdateRequest request)
    {
        if (id != request.Id)
        {
            _logger.LogWarning("The url id {UrlId} does not correspond to the body id {BodyId}", id, request.Id);
            return BadRequest($"The url id {id} does not correspond to the body id {request.Id}");
        }

        var rules = RulesFactory.Create(request.Rules);
        if (rules is null)
        {
            _logger.LogWarning("Rules {Rules} not found", request.Rules);
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
        if (gameUpdated is null)
        {
            _logger.LogWarning("Game with id {GameId} not found", id);
            return NotFound();
        }
        _logger.LogInformation("Game with id {GameId} updated", id);
        
        return Ok(gameUpdated.ToGameDetailDTO());
    }

    /// <summary>
    /// Delete a game
    /// </summary>
    /// <param name="id">The id of the game</param>
    /// <returns>No content</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(ulong id)
    {
        var deleted = await _manager.DeleteGame(id);

        if (!deleted)
        {
            _logger.LogWarning("Game with id {GameId} not found", id);
            return NotFound();
        }
        _logger.LogInformation("Game with id {GameId} deleted", id);
        
        return NoContent();
    }
}
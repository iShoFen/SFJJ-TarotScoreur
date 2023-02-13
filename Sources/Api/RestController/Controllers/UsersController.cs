using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Players;
using RestController.DTOs;
using RestController.DTOs.Extensions;
using RestController.Filter;

namespace RestController.Controllers;

/// <summary>
/// The users controller for REST API
/// </summary>
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<UsersController> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public UsersController(Manager manager, ILogger<UsersController> logger)
    {
        _manager = manager;
        _logger = logger;
        
        _logger.LogInformation("UsersController created");
    }

    /// <summary>
    /// Get all users with pagination
    /// </summary>
    /// <param name="pagination">The pagination</param>
    /// <returns>The list of users</returns>
    [HttpGet]
    public async Task<ActionResult> GetUsers([FromQuery] PaginationFilter pagination)
    {
        var users = (await _manager.GetUsers(pagination.Page, pagination.Count)).ToList();
        _logger.LogInformation("{UsersCount} users from {Page} page with {PageSize} size retrieved", 
            users.Count,
            pagination.Page,
            pagination.Count
        );

        return Ok(users.Select(x => x.UserToDTO()).ToList());
    }

    /// <summary>
    /// Get a user by id
    /// </summary>
    /// <param name="id">The id of the user</param>
    /// <returns>The user</returns>
    [HttpGet("{id}")]
    [ActionName(nameof(GetUser))]
    public async Task<ActionResult> GetUser(ulong id)
    {
        var user = await _manager.GetUserById(id);
        if (user is null)
        { 
            _logger.LogWarning("User with id {Id} not found", id);
            return NotFound();
        }
        var userDTO = user.UserToUserDetailDTO();
        userDTO.Games = (await _manager.GetGamesByPlayer(id, 1, 10)).Select(x => x.Id).ToList();
        userDTO.Groups = (await _manager.GetGroupsByPlayer(id, 1, 10)).Select(x => x.Id).ToList();
        _logger.LogInformation("User with id {Id} retrieved", id);
        
        return Ok(userDTO);
    }

    /// <summary>
    /// Get the games of a user
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <param name="pagination">The pagination</param>
    /// <returns>The games of the user</returns>
    [HttpGet("{userId}/games")]
    public async Task<ActionResult> GetGames(ulong userId, [FromQuery] PaginationFilter pagination)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null)
        {
            _logger.LogWarning("User with id {Id} not found", userId);
            return NotFound();
        }
        var games = (await _manager.GetGamesByPlayer(userId, pagination.Page,
            pagination.Count)).ToList();
        _logger.LogInformation("{GamesCount} games of User with id {User} from {Page} page with {PageSize} size retrieved", 
            games.Count,
            user.Id,
            pagination.Page,
            pagination.Count
        );

        return Ok(games.Select(x => x.ToGameDTO()).ToList());
    }

    /// <summary>
    /// Get the groups of a user
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <param name="pagination">The pagination</param>
    /// <returns>The groups of the user</returns>
    [HttpGet("{userId}/groups")]
    public async Task<ActionResult> GetGroups(ulong userId, [FromQuery] PaginationFilter pagination)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null)
        {
            _logger.LogWarning("User with id {Id} not found", userId);
            return NotFound();
        }
        var groups = (await _manager.GetGroupsByPlayer(userId, pagination.Page,
            pagination.Count)).ToList();
        _logger.LogInformation("{GroupsCount} groups of User with id {User} from {Page} page with {PageSize} size retrieved", 
            groups.Count,
            user.Id,
            pagination.Page,
            pagination.Count
        );
        
        return Ok(groups.Select(x => x.ToGroupDTO()).ToList());
    }

    /// <summary>
    /// Update a user
    /// </summary>
    /// <param name="id">The id of the user</param>
    /// <param name="request">The request</param>
    /// <returns>The updated user</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> PutUser(ulong id, UserUpdateRequest request)
    {
        if (id != request.Id)
        {
            _logger.LogWarning("The url id {UrlId} does not correspond to the body id {BodyId}", id, request.Id);
            return BadRequest();
        }

        var user = await _manager.UpdateUser(new User(request.Id,
            request.FirstName,
            request.LastName,
            request.Nickname,
            request.Avatar,
            request.Email,
            request.Password)
        );

        if (user is null)
        {
            _logger.LogWarning("User with id {Id} not found", id);
            
            return NotFound();
        }
        _logger.LogInformation("User with id {Id} updated", id);
        
        return Ok(user.UserToDTO());
    }

    /// <summary>
    /// Create a user
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>The created user</returns>
    [HttpPost]
    public async Task<ActionResult> PostUser(UserInsertRequest request)
    {
        var user = await _manager.InsertUser(request.FirstName, request.LastName, request.Nickname, request.Avatar,
            request.Email, request.Password);
        
        _logger.LogInformation("User with id {Id} created", user.Id);

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            user.UserToDTO());
    }

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="id">The id of the user</param>
    /// <returns>No content</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(ulong id)
    {
        var user = await _manager.GetUserById(id);
        if (user is null)
        {
            _logger.LogWarning("User with id {Id} not found", id);
            return NotFound();
        }
        await _manager.DeleteUser(user);
        
        _logger.LogInformation("User with id {Id} deleted", id);
        
        return NoContent();
    }
}
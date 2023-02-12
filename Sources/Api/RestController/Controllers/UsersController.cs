using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Players;
using RestController.DTOs;
using RestController.DTOs.Extensions;
using RestController.Filter;
using RestController.DTOs.Games;

namespace RestController.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly Manager _manager;

    public UsersController(Manager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult> GetUsers([FromQuery] PaginationFilter pagination)
    {
        var users = (await _manager.GetUsers(pagination.Page, pagination.Count)).ToList();

        return Ok(users.Select(x => x.UserToDTO()).ToList());
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetUser))]
    public async Task<ActionResult> GetUser(ulong id)
    {
        var user = await _manager.GetUserById(id);
        if (user is null) return NotFound();
        var userDTO = user.UserToUserDetailDTO();
        userDTO.Games = (await _manager.GetGamesByPlayer(id, 1, 10)).Select(x => x.Id).ToList();
        userDTO.Groups = (await _manager.GetGroupsByPlayer(id, 1, 10)).Select(x => x.Id).ToList();
        return Ok(userDTO);
    }

    [HttpGet("{userId}/games")]
    public async Task<ActionResult> GetGames(ulong userId, [FromQuery] PaginationFilter pagination)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null) return NotFound();
        var games = await _manager.GetGamesByPlayer(userId, pagination.Page,
            pagination.Count);
        return Ok(games.Select(x => x.ToGameDTO()).ToList());
    }

    [HttpGet("{userId}/groups")]
    public async Task<ActionResult> GetGroups(ulong userId, [FromQuery] PaginationFilter pagination)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null) return NotFound();
        var groups = await _manager.GetGroupsByPlayer(userId, pagination.Page,
            pagination.Count);
        return Ok(groups.Select(x => x.ToGroupDTO()).ToList());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutUser(ulong id, UserUpdateRequest request)
    {
        if (id != request.Id) return BadRequest();

        var user = await _manager.UpdateUser(new User(request.Id,
            request.FirstName,
            request.LastName,
            request.Nickname,
            request.Avatar,
            request.Email,
            request.Password)
        );

        return user is null ? NotFound() : Ok(user.UserToDTO());
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(UserInsertRequest request)
    {
        var user = await _manager.InsertUser(request.FirstName, request.LastName, request.Nickname, request.Avatar,
            request.Email, request.Password);

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            user.UserToDTO());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(ulong id)
    {
        var user = await _manager.GetUserById(id);
        if (user is null) return NotFound();
        await _manager.DeleteUser(user);
        return NoContent();
    }
}
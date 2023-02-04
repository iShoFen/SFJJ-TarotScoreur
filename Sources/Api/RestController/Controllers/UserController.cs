using Microsoft.AspNetCore.Mvc;
using Model;
using RestController.Filter;
using RestController.DTOs.Extensions;
using RestController.DTOs;

namespace RestController.Controllers;

[Route("user/")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly Manager _manager;
    public UserController(Manager manager)
    {
        _manager = manager;

    }

    [HttpGet]
    public async Task<ActionResult> GetUsers([FromQuery] PaginationFilter paginationFilter)
    {
        var users = (await _manager.GetUsers(paginationFilter.Page, paginationFilter.Count)).ToList();

        return Ok(users.Select(x => x.UserToDTO()).ToList());


    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetUser))]
    public async Task<ActionResult<UserDTO>> GetUser(ulong id)
    {
        var user = await _manager.GetUserById(id);
        if (user is null) return NotFound();
        return Ok(user.UserToDTO());
    }

    [HttpGet("{userId}/game")]
    public async Task<ActionResult<GameDetailDTO>> GetGames(ulong userId, [FromQuery] PaginationFilter paginationFilter)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null) return NotFound();
        var games = await _manager.GetGamesByPlayer(userId, paginationFilter.Page * paginationFilter.Count,
            paginationFilter.Count);
        return Ok(games.Select(x => x.ToGameDetailDTO()).ToList());
    }
/*
    [HttpGet("{userId}/game/{gameId}")]
    public async Task<ActionResult<GameDTO>> GetGameById(ulong userId, ulong gameId)
    {
        var user = await _manager.GetUserById(userId);
        if (user is null) return NotFound();
        var game = await _manager.GetGamesByPlayer();
    }
    */



    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(ulong id, UserDTO userDTO)
    {
        if (id != userDTO.Id) return BadRequest();
        var user = await _manager.UpdateUser(userDTO.DTOToUser());
        if (user is null) return NotFound();
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTOPostRequest userDtoPostRequest)
    {
        var user = await _manager.InsertUser(userDtoPostRequest.FirstName, userDtoPostRequest.LastName, userDtoPostRequest.Nickname, userDtoPostRequest.Avatar, userDtoPostRequest.Email, userDtoPostRequest.Password);

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            user.UserToDTO());

    }
}
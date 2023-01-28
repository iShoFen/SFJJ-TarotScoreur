using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Players;
using Tarot2B2Model;
using TarotDB;
using Tarot2B2Model.ExtensionsAndMappers;
using Model.Data;
using Model;
using System.Linq;
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
        var users = (await _manager.GetPlayers(paginationFilter.Page, paginationFilter.Count)).ToList();

        return Ok(users.Select(x => x.PlayerToDTO()).ToList());


    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetUser))]
    public async Task<ActionResult<UserDTO>> GetUser(ulong id)
    {
        var user = await _manager.GetPlayerById(id);
        if (user is null) return NotFound();
        return Ok(user.PlayerToDTO());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(ulong id, UserDTO userDTO)
    {
        if (id != userDTO.Id) return BadRequest();
        var user = await _manager.UpdatePlayer(userDTO.DTOToPlayer());
        if (user is null) return NotFound();
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
    {
        var user = await _manager.InsertPlayer(userDto.FirstName, userDto.LastName, userDto.Nickname, userDto.Avatar);

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            user.PlayerToDTO());

    }
}
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Players;
using StubContext;
using Tarot2B2Model;
using TarotDB;

namespace RestController.Controllers;

[Route("user/")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly TarotDbContext _context;
    public UserController(TarotDbContext context)
    {
        _context = context;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        return await _context.Users
            .Select(x => UserToDTO(x.ToModel()))
            .ToListAsync();

    }
    
    [HttpGet("{id}")]
    [ActionName(nameof(GetUser))]
    public async Task<ActionResult<UserDTO>> GetUser(ulong id)
    {
        var userEntity = _context.Users.FindAsync(id);
        return UserToDTO(userEntity.Result.ToModel());
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDto)
    {
        var user = new User(userDto.FirstName, userDto.LastName, userDto.Nickname, userDto.Avatar, "email", "password");
        _context.Users.Add(user.ToEntity());
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            UserToDTO(user));

    }



    private static UserDTO UserToDTO(User user) =>
        new ()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Nickname = user.NickName,
            Avatar = user.Avatar,
            Email = user.Email
        };
}
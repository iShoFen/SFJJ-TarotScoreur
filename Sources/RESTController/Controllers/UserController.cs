using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Players;
using StubContext;
using Tarot2B2Model;
using TarotDB;

namespace RestController.Controllers;

[Route("user/")]
[ApiController]
public class UserController
{
    private TarotDbContext _context;
    public UserController(TarotDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAllUser()
    {
        var userEntities = _context.Users.ToList();
        var users = userEntities.ToModels();
        return users;

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(ulong id)
    {
        var userEntity = _context.Users.FindAsync(id);
        return userEntity.Result!.ToModel();
    }
}
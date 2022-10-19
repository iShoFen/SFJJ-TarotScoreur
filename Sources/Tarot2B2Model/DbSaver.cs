using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbSaver : ISaver
{
    protected DbContext Context { get; }

    public DbSaver(DbContext context)
    {
        Context = context;
    }

    public DbSaver() : this(new TarotDbContext())
    {
    }

    public async Task<Player> SavePlayer(Player player)
    {
        ((TarotDbContext)Context).Players.Add(player.ToEntity());
        await Context.SaveChangesAsync();
        return player;
    }

    public async Task<Game> SaveGame(Game game)
    {
        ((TarotDbContext)Context).Games.Add(game.ToEntity());
        await Context.SaveChangesAsync();
        return game;
    }

    public async Task<Group> SaveGroup(Group group)
    {
        ((TarotDbContext)Context).Groups.Add(group.ToEntity());
        await Context.SaveChangesAsync();
        return group;
    }
}
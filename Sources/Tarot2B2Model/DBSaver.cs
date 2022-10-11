using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DBSaver : ISaver
{
    protected DbContext Context { get; }
    
    public DBSaver(DbContext context)
    {
        Context = context;
    }
    public DBSaver() : this(new TarotDBContext()){}
    public async Task<Player> SavePlayer(Player player)
    { 
        ((TarotDBContext) Context).Players.Add(player.ToEntity());
        await Context.SaveChangesAsync();
        return player;
    }

    public async Task<Game> SaveGame(Game game)
    {
        ((TarotDBContext) Context).Games.Add(game.ToEntity());
        await Context.SaveChangesAsync();
        return game;
    }

    public async Task<Group> SaveGroup(Group group)
    {
        ((TarotDBContext) Context).Groups.Add(group.ToEntity());
        await Context.SaveChangesAsync();
        return group;
    }
}
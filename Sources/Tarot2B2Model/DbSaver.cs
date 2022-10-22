using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbSaver : ISaver
{
	private readonly DbContextOptions<TarotDbContext> _options;
	private readonly Type _dbContextType;

    public DbSaver() : this(typeof(TarotDbContext), @"Data Source=TarotScoreur.db")
    {
    }


    public DbSaver(Type type, string connectionString)
    {
        Mapper.Reset();

        var connection = new SqliteConnection(connectionString);
        connection.Open();
        _options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
        _dbContextType = type;

        var context = InitContext();
        context.Database.EnsureCreated();
    }
    
    private TarotDbContext InitContext() => (TarotDbContext)Activator.CreateInstance(_dbContextType, _options)!;

    public async Task<Player?> SavePlayer(Player player)
    {
        Mapper.Reset();

        await using var context = InitContext();
        var playerEntity = player.ToEntity();
        
        if (await context.Players.FindAsync(playerEntity.Id) != null) return null;
        var result = await context.AddAsync(playerEntity);
        if (result.State != EntityState.Added) return null;

        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }

    public async Task<Game?> SaveGame(Game game)
    {
        Mapper.Reset();

        await using var context = InitContext();
        var gameEntity = game.ToEntity();
        var result = await context.AddAsync(gameEntity);
        if (result.State != EntityState.Added) return null;

        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }

    public async Task<Group?> SaveGroup(Group group)
    {
        Mapper.Reset();

        await using var context = InitContext();
        var groupEntity = group.ToEntity();
        var result = await context.AddAsync(groupEntity);
        if (result.State != EntityState.Added) return null;

        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }
}
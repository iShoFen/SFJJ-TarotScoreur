using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbSaver : ISaver
{
    private DbContextOptions<TarotDbContext> Options { get; }

    public DbSaver() : this(@"Data Source=TarotScoreur.db")
    {
    }


    public DbSaver(string connectionString)
    {
        Mapper.Reset();

        var connection = new SqliteConnection(connectionString);
        connection.Open();
        Options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;

        using var context = new TarotDbContext(Options);
        context.Database.EnsureCreated();
    }

    public async Task<Player?> SavePlayer(Player player)
    {
        Mapper.Reset();

        await using var context = new TarotDbContext(Options);
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

        await using var context = new TarotDbContext(Options);
        var gameEntity = game.ToEntity();
        var result = await context.AddAsync(gameEntity);
        if (result.State != EntityState.Added) return null;

        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }

    public async Task<Group?> SaveGroup(Group group)
    {
        Mapper.Reset();

        await using var context = new TarotDbContext(Options);
        var groupEntity = group.ToEntity();
        var result = await context.AddAsync(groupEntity);
        if (result.State != EntityState.Added) return null;

        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }
}
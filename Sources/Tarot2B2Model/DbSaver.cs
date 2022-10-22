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

        var result = await context.AddAsync(playerEntity);
        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }

    public async Task<Game?> SaveGame(Game game)
    {
        Mapper.Reset();

        await using var context = new TarotDbContext(Options);
        var gameEntity = game.ToEntity();

        var result = await context.AddAsync(gameEntity);
        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }

    public async Task<Group?> SaveGroup(Group group)
    {
        Mapper.Reset();

        await using var context = new TarotDbContext(Options);
        var groupEntity = group.ToEntity();

        var existingGroup = await context.Groups.FirstOrDefaultAsync(g => g.Name == groupEntity.Name);
        // Test if Group with the same name and different ids already exists
        if (existingGroup != null && existingGroup.Id != groupEntity.Id) return null;

        var result = await context.AddAsync(groupEntity);
        await context.SaveChangesAsync();
        return result.Entity.ToModel();
    }
}
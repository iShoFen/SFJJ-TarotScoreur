using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

/// <summary>
/// The database Loader manager
/// </summary>
public class DbSaver : ISaver
{
	/// <summary>
	/// The options for the database
	/// </summary>
	private readonly DbContextOptions<TarotDbContext> _options;
	
	/// <summary>
	/// The type of the database context
	/// </summary>
	private readonly Type _dbContextType;

	/// <summary>
	/// Default constructor
	/// </summary>
    public DbSaver() : this(typeof(TarotDbContext), @"Data Source=TarotScoreur.db")
    {
    }
    
	/// <summary>
	/// Constructor type and connection string
	/// </summary>
	/// <param name="contextType"> The type of the database context</param>
	/// <param name="connectionString"> The connection string</param>
    public DbSaver(Type contextType, string connectionString)
    {
        Mapper.Reset();

        var connection = new SqliteConnection(connectionString);
        connection.Open();
        _options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
        _dbContextType = contextType;

        var context = InitContext();
        context.Database.EnsureCreated();
    }
	
	/// <summary>
	/// Initialize the database context
	/// </summary>
	/// <returns> The database context </returns>
    private TarotDbContext InitContext() => (TarotDbContext)Activator.CreateInstance(_dbContextType, _options)!;

    /// <summary>
    ///Save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    /// <returns>The player saved</returns>
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

    /// <summary>
    ///Save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    /// <returns>The game saved</returns>
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

    /// <summary>
    ///Save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    /// <returns>The group saved</returns>
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
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model.Games;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbReader
{
    /// <summary>
    /// The options for the database
    /// </summary>
    private readonly DbContextOptions<TarotDbContext> _contextOptions;

    /// <summary>
    /// The type of the database context
    /// </summary>
    private readonly Type _dbContextType;

    /// <summary>
    /// Default constructor
    /// </summary>
    public DbReader()
        : this(typeof(TarotDbContext), @"Data Source=TarotScoreur.db")
    {
    }

    /// <summary>
    /// Constructor type and connection string
    /// </summary>
    /// <param name="contextType"> The type of the database context</param>
    /// <param name="connectionString"> The connection string</param>
    public DbReader(Type contextType, string connectionString)
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        _contextOptions = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
        _dbContextType = contextType;

        using var context = GetContext();
        context.Database.EnsureCreated();
    }

    /// <summary>
    /// Initialize the database context and reset the Mapper.
    /// </summary>
    /// <returns>The database context</returns>
    private TarotDbContext GetContext()
    {
        Mapper.Reset();
        return (TarotDbContext)Activator.CreateInstance(_dbContextType, _contextOptions)!;
    }

    public async Task<IEnumerable<KeyValuePair<int, Hand>>> GetHandsByGame(ulong gameId, int start, int count)
    {
        if (start <= 0 || count <= 0) return await Task.FromResult(new List<KeyValuePair<int, Hand>>());

        await using var context = GetContext();
        return (context.Games
                    .Where(g => g.Id == gameId)
                    .Include(g => g.Hands)
                    .FirstOrDefault()
                    ?.Hands
                ?? new List<HandEntity>())
            .Paginate(start, count)
            .ToModels()
            .ToDictionary(h => h.Number);
    }
}
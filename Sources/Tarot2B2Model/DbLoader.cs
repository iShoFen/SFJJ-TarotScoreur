using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

/// <summary>
/// The database Loader manager
/// </summary>
public class DbLoader : ILoader
{
	/// <summary>
	/// The options for the database
	/// </summary>
    internal readonly DbContextOptions<TarotDbContext> Options;
	
	/// <summary>
	/// The type of the database context
	/// </summary>
    internal readonly Type DbContextType;

	/// <summary>
	/// Default constructor
	/// </summary>
    public DbLoader() : this(typeof(TarotDbContext),@"Data Source=TarotScoreur.db")
    {
    }

	/// <summary>
	/// Constructor type and connection string
	/// </summary>
	/// <param name="contextType"> The type of the database context</param>
	/// <param name="connectionString"> The connection string</param>
    public DbLoader(Type contextType, string connectionString)
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        Options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
        DbContextType = contextType;

        using var context = InitContext();
        context.Database.EnsureCreated();
    }

	/// <summary>
	/// Initialize the database context
	/// </summary>
	/// <returns> The database context </returns>
    private TarotDbContext InitContext() => (TarotDbContext)Activator.CreateInstance(DbContextType, Options)!;
    
	/// <summary>
	/// Load a game by name
	/// </summary>
	/// <param name="name">Name of the game</param>
	/// <returns>A game</returns>
    public async Task<Game?> LoadGameByName(string name)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
    }

	/// <summary>
	/// Load games by player
	/// </summary>
	/// <param name="player">Player to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
	{
		if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
		Mapper.Reset();
		await using var context = InitContext();

		return (await context.Games.Include(g => g.Players)
	        .Where(g => g.Players.Any(p => p.Id == player.Id))
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by start date
	/// </summary>
	/// <param name="startDate">Start date of games</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Games.Where(g => g.StartDate == startDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by end date
	/// </summary>
	/// <param name="endDate">End date of games</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Games.Where(g => g.EndDate == endDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by an interval of dates
	/// </summary>
	/// <param name="startDate">Start date of the interval</param>
	/// <param name="endDate">End date of the interval</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by an interval of dates and a group
	/// </summary>
	/// <param name="startDate">Start date of the interval</param>
	/// <param name="endDate">End date of the interval</param>
	/// <param name="group">Group to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
        Group group, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        var groupPlayersIds = group.Players.Select(p => p.Id).ToList();
        
        return (await context.Games.Include(g => g.Players)
	        .Where(g => g.StartDate >= startDate
	                    && g.EndDate <= endDate
	                    && g.Players.Count == group.Players.Count
	                    && g.Players.All(p => groupPlayersIds.Contains(p.Id)))
            .Skip((page - 1) * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by an interval of dates and a player
	/// </summary>
	/// <param name="startDate">Start date of the interval</param>
	/// <param name="endDate">End date of the interval</param>
	/// <param name="player">Player to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
        Player player, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        
        return (await context.Games.Include(g => g.Players)
            .Where(g => g.StartDate >= startDate
                        && g.EndDate <= endDate
                        && g.Players.Select(pe => pe.Id).Contains(player.Id))
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load games by a group
	/// </summary>
	/// <param name="group">Group to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        
        var groupPlayersIds = group.Players.Select(p => p.Id).ToList();
        return (await context.Games.Include(g => g.Players)
	        .Where(g => g.Players.Count == group.Players.Count 
	                    && g.Players.All(p => groupPlayersIds.Contains(p.Id)))
            .Skip((page - 1) * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load all games
	/// </summary>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Game>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Games
	        .Skip((page - 1) * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by lastname and nickname
	/// </summary>
	/// <param name="lastName">Lastname to search</param>
	/// <param name="nickname">Nickname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
        int pageSize)
    { 
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.LastName == lastName && p.Nickname == nickname)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by firstName and nickname
	/// </summary>
	/// <param name="firstName">Firstname to search</param>
	/// <param name="nickname">Nickname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName && p.Nickname == nickname)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by firstname and lastname
	/// </summary>
	/// <param name="firstName">Firstname to search</param>
	/// <param name="lastName">Lastname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName && p.LastName == lastName)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by nickname
	/// </summary>
	/// <param name="nickname">Nickname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.Nickname == nickname)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }
	
	/// <summary>
	/// Load a player by lastname
	/// </summary>
	/// <param name="lastName">Lastname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.LastName == lastName)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by firstname
	/// </summary>
	/// <param name="firstName">Firstname to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName)
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load all players
	/// </summary>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Players.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load a player by group
	/// </summary>
	/// <param name="group">Group to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
    {    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Player>());
     	    
             Mapper.Reset();
             await using var context = InitContext();
             return await Task.FromResult(context.Groups.Include(g => g.Players)
     	        .First(g => g.Id == group.Id).Players
     	        .Skip((page - 1) * pageSize).Take(pageSize).ToModels());
	
    }

	/// <summary>
	/// Load a group by name
	/// </summary>
	/// <param name="name">Name to search</param>
	/// <returns>A group</returns>
    public async Task<Group?> LoadGroupsByName(string name)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Groups.Include(g => g.Players)
	        .FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
    }

	/// <summary>
	/// Load all groups
	/// </summary>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Group>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Groups.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }
	
	/// <summary>
	/// Load a group by player
	/// </summary>
	/// <param name="player">Player to search</param>
	/// <param name="page"> Number of the page to load</param>
	/// <param name="pageSize">Size of the page</param>
	/// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<Group>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Groups.Include(g => g.Players)
	        .Where(g => g.Players.Select(pe => pe.Id).Contains(player.Id))
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

	/// <summary>
	/// Load hands by game
	/// </summary>
	/// <param name="game"></param>
	/// <param name="page"></param>
	/// <param name="pageSize"></param>
	/// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
    {
	    if (page == 0 || pageSize == 0) return await Task.FromResult(new List<KeyValuePair<int, Hand>>());
	    
        Mapper.Reset();
        await using var context = InitContext();
        return (await context.Hands.Include(h => h.Game)
	        .Where(h => h.Game.Id == game.Id).Skip((page - 1) * pageSize).Take(pageSize)
	        .ToListAsync()).ToModels().ToDictionary(h => h.Number, h => h);
    }
}
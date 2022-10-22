using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbLoader : ILoader
{
    private readonly DbContextOptions<TarotDbContext> _options;
    private readonly Type _dbContextType;

    public DbLoader() : this(typeof(TarotDbContext),@"Data Source=TarotScoreur.db")
    {
    }

    public DbLoader(Type contextType, string connectionString)
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();
        _options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;
        _dbContextType = contextType;

        using var context = InitContext();
        context.Database.EnsureCreated();
    }

    private TarotDbContext InitContext() => (TarotDbContext)Activator.CreateInstance(_dbContextType, _options)!;
    
    public async Task<Game?> LoadGameByName(string name)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
    }

    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Include(g => g.Players)
	        .Where(g => g.Players.Any(p => p.Equals(player)))
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Where(g => g.StartDate == startDate)
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Where(g => g.EndDate == endDate)
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate)
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
        Group group, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Include(g => g.Players)
	        .Where(g => g.StartDate >= startDate
	                    && g.EndDate <= endDate
	                    && group.Players.All(p => g.Players.Select(pe => pe.Id).Contains(p.Id)))
            .Skip(page - 1 * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
        Player player, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Include(g => g.Players)
            .Where(g => g.StartDate >= startDate
                        && g.EndDate <= endDate
                        && g.Players.Select(pe => pe.Id).Contains(player.Id))
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games.Include(g => g.Players)
	        .Where(g => group.Players.All(p => g.Players.Select(pe => pe.Id).Contains(p.Id)))
            .Skip(page - 1 * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Games
	        .Skip(page - 1 * pageSize)
	        .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
        int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.LastName == lastName && p.Nickname == nickname)
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName && p.Nickname == nickname)
            .Skip(page - 1 * pageSize)
            .Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName && p.LastName == lastName)
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.Nickname == nickname)
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }


    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.LastName == lastName)
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Where(p => p.FirstName == firstName)
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }


    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Players.Include(p => p.Groups)
	        .Where(p => group.Players.Select(pe => pe.Id).Contains(p.Id))
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<Group?> LoadGroupsByName(string name)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Groups.Include(g => g.Players)
	        .FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
    }

    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Groups.Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }


    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Groups.Include(g => g.Players)
	        .Where(g => g.Players.Select(pe => pe.Id).Contains(player.Id))
            .Skip(page - 1 * pageSize).Take(pageSize).ToListAsync()).ToModels();
    }

    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
    {
        Mapper.Reset();

        await using var context = InitContext();
        return (await context.Hands.Include(h => h.Game)
	        .Where(h => h.Game.Id == game.Id).Skip(page - 1 * pageSize).Take(pageSize)
	        .ToListAsync()).ToModels().ToDictionary(h => h.Number, h => h);
    }
}
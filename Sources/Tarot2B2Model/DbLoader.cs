using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbLoader : ILoader
{
	private DbContextOptions<TarotDbContext> Options;

	public DbLoader() : this(@"Data Source=TarotScoreur.db")
	{
	}


	public DbLoader(string connectionString)
	{
		var connection = new SqliteConnection(connectionString);
		connection.Open();
		Options = new DbContextOptionsBuilder<TarotDbContext>().UseSqlite(connection).Options;

		using var context = new TarotDbContext(Options);
		context.Database.EnsureCreated();
	}

	public async Task<Game?> LoadGameByName(string name)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return (await context.Games.FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
	}

	public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return (await context.Games.Where(g => g.Players.Any(p => p.Equals(player)))
			.Skip(page - 1 * pageSize)
			.Take(pageSize).ToListAsync()).ToModels();
	}

	public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return (await context.Games.Where(g => g.StartDate == startDate)
			.Skip(page - 1 * pageSize)
			.Take(pageSize).ToListAsync()).ToModels();
	}

	public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games.Where(g => g.EndDate == endDate)
			.Skip(page - 1 * pageSize)
			.Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
		int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate)
			.Skip(page - 1 * pageSize)
			.Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
		Group group, int page, int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games
			.Where(g => g.StartDate >= startDate 
			            && g.EndDate <= endDate 
			            && group.Players.All(p => g.Players.Select(pe => pe.Id).Contains(p.Id)))
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
		Player player, int page, int pageSize)
	{
		Mapper.Reset();

		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games
			.Where(g => g.StartDate >= startDate 
			            && g.EndDate <= endDate 
			            && g.Players.Select(pe => pe.Id).Contains(player.Id))
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games.Where(g => group.Players.All(
				p => g.Players.Select(pe => pe.Id).Contains(p.Id)))
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Games.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
		int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.LastName == lastName && p.Nickname == nickname)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
		int pageSize)
	{ 
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.FirstName == firstName && p.Nickname == nickname)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
		int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.FirstName == firstName && p.LastName == lastName)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.Nickname == nickname)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}


	public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.LastName == lastName)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => p.FirstName == firstName)
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
	{ 
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}


	public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Players.Where(p => group.Players.Select(pe => pe.Id).Contains(p.Id))
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<Group?> LoadGroupsByName(string name)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return (await context.Groups.FirstOrDefaultAsync(g => g.Name == name))?.ToModel();
	}

	public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Groups.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}


	public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() => context.Groups.Where(g => g.Players.Select(pe => pe.Id).Contains(player.Id))
			.Skip(page - 1 * pageSize).Take(pageSize).AsEnumerable().ToModels());
	}

	public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
	{
		Mapper.Reset();
		
		await using var context = new TarotDbContext(Options);
		return await Task.Run(() =>
			context.Hands.Where(h => h.Game.Id == game.Id).Skip(page - 1 * pageSize).Take(pageSize)
				.AsEnumerable().ToModels().ToDictionary(h => h.Number, h => h));
	}
}
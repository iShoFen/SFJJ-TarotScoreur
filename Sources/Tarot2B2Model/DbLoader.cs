using Microsoft.EntityFrameworkCore;
using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DbLoader : ILoader
{
    protected DbContext Context { get; }

    public DbLoader(DbContext context)
    {
        Context = context;
    }

    public DbLoader() : this(new TarotDbContext())
    {
    }

    public async Task<Game?> LoadGameByName(string name)
        => (await ((TarotDbContext)Context).Games.SingleOrDefaultAsync(g => g.Name.Contains(name)))?.ToModel();

    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g => g.Players.Any(p => p.Id == player.Id))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g => g.StartDate == startDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g => g.EndDate == endDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
        Group group, int page, int pageSize)
        => (await ((TarotDbContext)Context).Games
            .Where(g => g.StartDate >= startDate && g.EndDate <= endDate && g.Id == group.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
        Player player, int page,
        int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g =>
                g.StartDate >= startDate && g.EndDate <= endDate && g.Players.Any(p => p.ToModel().Equals(player)))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
        => (await ((TarotDbContext)Context).Games.Where(g => g.Id == group.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
        => (await ((TarotDbContext)Context).Games
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
        int pageSize)
        => (await ((TarotDbContext)Context).Players
            .Where(p => p.LastName.Contains(lastName) && p.Nickname.Contains(nickname))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
        => (await ((TarotDbContext)Context).Players
            .Where(p => p.FirstName.Contains(firstName) && p.Nickname.Contains(nickname))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
        => (await ((TarotDbContext)Context).Players
            .Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
        => (await ((TarotDbContext)Context).Players.Where(p => p.Nickname.Contains(nickname))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
        => (await ((TarotDbContext)Context).Players.Where(p => p.LastName.Contains(lastName))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
        => (await ((TarotDbContext)Context).Players.Where(p => p.FirstName.Contains(firstName))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
        => (await ((TarotDbContext)Context).Players
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
        => (await ((TarotDbContext)Context).Players.Where(p => group.Players.Contains(p.ToModel()))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<Group?> LoadGroupsByName(string name)
        => (await ((TarotDbContext)Context).Groups.Where(g => g.Name == name)
            .FirstOrDefaultAsync())?.ToModel();

    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
        => (await ((TarotDbContext)Context).Groups
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
        => (await ((TarotDbContext)Context).Groups.Where(g => g.Players.Contains(player.ToEntity()))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).ToModels();

    public async Task<IRules?> LoadRule(string name)
        => await Task.FromResult(RulesFactory.Rules.SingleOrDefault(r => r.Key.Equals(name)).Value);

    public async Task<IEnumerable<IRules>> LoadAllRules(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
        => (await ((TarotDbContext)Context).Hands.Where(h => h.Game.ToModel().Equals(game))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()).Select(h => new KeyValuePair<int, Hand>(h.Number, h.ToModel())).ToList();
}
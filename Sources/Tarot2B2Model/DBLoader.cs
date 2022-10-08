using Model;
using Model.data;
using Model.games;
using TarotDB;

namespace Tarot2B2Model;

public class DBLoader : ILoader
{
    public Game? LoadGameByName(string name)
    {
        Game? game = null;
        using (var context = new TarotDBContext())
        {
            game = context.Games.Single(g => g.Name.Contains(name)).ToModel();
        }

        return game;
    }

    public IEnumerable<Game> LoadGameByPlayer(Player player, int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.Players.Any(p => p.ToModel().Equals(player)))
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }
        return games;
    }

    public IEnumerable<Game> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.StartDate == startDate)
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }

        return games;
    }

    public IEnumerable<Game> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.EndDate == endDate)
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }

        return games;
    }

    public IEnumerable<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate)
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }

        return games;
    }

    public IEnumerable<Game> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate, Group group, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate, Player player, int page,
        int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.StartDate >= startDate && g.EndDate <= endDate && g.Players.Any(p => p.ToModel().Equals(player)))
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }

        return games;
    }

    public IEnumerable<Game> LoadGameByGroup(Group group, int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Where(g => g.Players.Any(p => group.Players.Contains(p.ToModel())))
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }

        return games;
    }

    public IEnumerable<Game> LoadAllGames(int page, int pageSize)
    {
        List<Game> games;
        using (var context = new TarotDBContext())
        {
            games = context.Games.Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(g => g.ToModel())
                                 .ToList();
        }
        return games;
    }

    public IEnumerable<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.LastName.Contains(lastName) && p.Nickname.Contains(nickname))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }

        return players;
    }

    public IEnumerable<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.FirstName.Contains(firstName) && p.Nickname.Contains(nickname))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }

        return players;

    }

    public IEnumerable<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }

        return players;
    }

    public IEnumerable<Player> LoadPlayerByNickname(string nickname, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.Nickname.Contains(nickname))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }

        return players;
    }

    public IEnumerable<Player> LoadPlayerByLastName(string lastName, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.LastName.Contains(lastName))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }

        return players;
    }

    public IEnumerable<Player> LoadPlayerByFirstName(string firstName, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => p.LastName.Contains(firstName))
                .Skip((page-1) * pageSize)
                .Take(pageSize)
                .Select(p => p.ToModel())
                .ToList();
        }
        return players;
    }

    public IEnumerable<Player> LoadAllPlayer(int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }
        return players;
    }

    public IEnumerable<Player> LoadPlayersByGroup(Group group, int page, int pageSize)
    {
        List<Player> players;
        using (var context = new TarotDBContext())
        {
            players = context.Players.Where(p => group.Players.Contains(p.ToModel()))
                                     .Skip((page-1) * pageSize)
                                     .Take(pageSize)
                                     .Select(p => p.ToModel())
                                     .ToList();
        }
        return players;
    }

    public Group? LoadGroupsByName(string name)
    {
        Group group;
        using (var context = new TarotDBContext())
        {
            group = context.Groups.FirstOrDefault(g => g.Name == name)?.ToModel();
        }
        return group;
    }

    public IEnumerable<Group> LoadAllGroups(int page, int pageSize)
    {
        List<Group> groups;
        using (var context = new TarotDBContext())
        {
            groups = context.Groups.Skip((page-1) * pageSize)
                                   .Take(pageSize)
                                   .Select(g => g.ToModel())
                                   .ToList();
        }
        return groups;
    }

    public IEnumerable<Group> LoadGroupsByPlayer(Player player, int page, int pageSize)
    {
        List<Group> groups;
        using (var context = new TarotDBContext())
        {
            groups = context.Groups.Where(g => g.Players.Any(p => p.ToModel().Equals(player)))
                                   .Skip((page-1) * pageSize)
                                   .Take(pageSize)
                                   .Select(g => g.ToModel())
                                   .ToList();
        }
        return groups;
    }

    public IRules? LoadRule(string name)
    {
        return RulesFactory.Rules.SingleOrDefault(r => r.Key.Equals(name)).Value;
    }

    public IEnumerable<IRules> LoadAllRules(int page, int pageSize)
    {
        return RulesFactory.Rules.Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select(r => r.Value)
                                 .ToList();
    }

    public IEnumerable<KeyValuePair<int, Hand>> LoadHandByGame(Game game, int page, int pageSize)
    {
        List<KeyValuePair<int, Hand>> hands;
        using (var context = new TarotDBContext())
        {
            hands = context.Hands.Where(h => h.Game.ToModel().Equals(game))
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .Select((h, i) => new KeyValuePair<int, Hand>(i, h.ToModel()))
                                 .ToList();
        }
        return hands;
    }
}
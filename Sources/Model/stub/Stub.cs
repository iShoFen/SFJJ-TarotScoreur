using Model.data;
using Model.games;

namespace Model.stub;

public class Stub : ILoader
{
    private readonly List<Game> _gameList= new();
    private readonly List<Player> _playerList = new();
    private readonly List<Group> _groupList = new();

    public Stub()
    {
        SetGameList();
        SetPlayerList();
        SetGroupList();
    }

    private void SetGameList()
    {
        _gameList.Add(new Game(1UL, "Game 1", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(2UL, "Game 2", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(3UL, "Game 3", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(4UL, "Game 4", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(5UL, "Game 5", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(6UL, "Game 6", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(7UL, "Game 7", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(8UL, "Game 8", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(9UL, "Game 9", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(10UL, "Game 10", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(11UL, "Game 11", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(12UL, "Game 12", new FrenchTarotRules(), DateTime.Now, null));
        _gameList.Add(new Game(13UL, "Game 13", new FrenchTarotRules(), new DateTime(2022,09,21), new DateTime(2022,09,25)));
        _gameList.Add(new Game(14UL, "Game 14", new FrenchTarotRules(), new DateTime(2022,09,21), new DateTime(2022,09,25)));
        _gameList.Add(new Game(15UL, "Game 15", new FrenchTarotRules(), new DateTime(2022,09,21), new DateTime(2022,09,25)));
        _gameList.Add(new Game(16UL, "Game 16", new FrenchTarotRules(), new DateTime(2022,09,21), new DateTime(2022,09,25)));
        _gameList.Add(new Game(17UL, "Game 17", new FrenchTarotRules(), new DateTime(2022,09,18), new DateTime(2022,09,23)));
        _gameList.Add(new Game(18UL, "Game 18", new FrenchTarotRules(), new DateTime(2022,09,18), new DateTime(2022,09,23)));
        _gameList.Add(new Game(19UL, "Game 19", new FrenchTarotRules(), new DateTime(2022,09,18), new DateTime(2022,09,23)));
        _gameList.Add(new Game(20UL, "Game 20", new FrenchTarotRules(), new DateTime(2022,09,18), new DateTime(2022,09,23)));
        _gameList.Add(new Game(21UL, "Game 21", new FrenchTarotRules(), new DateTime(2022,09,18), new DateTime(2022,09,23)));
        _gameList.Add(new Game(22UL, "Game 22", new FrenchTarotRules(), new DateTime(2022,08,01), new DateTime(2022,08,15)));
        _gameList.Add(new Game(23UL, "Game 23", new FrenchTarotRules(), new DateTime(2022,08,01), new DateTime(2022,08,15)));
        _gameList.Add(new Game(24UL, "Game 24", new FrenchTarotRules(), new DateTime(2022,08,01), new DateTime(2022,08,15)));
        _gameList.Add(new Game(25UL, "Game 25", new FrenchTarotRules(), new DateTime(2022,08,01), new DateTime(2022,08,15)));
    }
    
    private void SetPlayerList()
    {
        _playerList.Add(new Player("Jean", "BON", "JEBO", "avatar1"));
        _playerList.Add(new Player("Jean", "MAUVAIS", "JEMA", "avatar2"));
        _playerList.Add(new Player("Jean", "MOYEN", "KIKOU7", "avatar3"));
        _playerList.Add(new Player("Michel", "BELIN", "FRIPOUILLE", "avatar4"));
        _playerList.Add(new Player("Albert", "GOL", "LOL", "avatar1"));
        _playerList.Add(new Player("Julien", "PETIT", "THEGIANT", "avatar2"));
        _playerList.Add(new Player("Simon", "SEBAT", "SEBAT", "avatar1"));
        _playerList.Add(new Player("Jordan", "LEG", "BIGBRAIN", "avatar1"));
        _playerList.Add(new Player("Samuel", "LeChanteur", "SS", "avatar1"));
        _playerList.Add(new Player("Brigitte", "PUECH", "XXFRIPOUILLEXX", "avatar1"));
        _playerList.Add(new Player("Jeanne", "LERICHE", "JEMA", "avatar2"));
        _playerList.Add(new Player("Jules", "INFANTE", "KIKOU7", "avatar3"));
        _playerList.Add(new Player("Anne", "SAURIN", "FRIPOUILLE", "avatar4"));
        _playerList.Add(new Player("Marine", "TABLETTE", "LOL", "avatar1"));
        _playerList.Add(new Player("Eliaz", "DU JARDIN", "THEGIANT", "avatar2"));
        _playerList.Add(new Player("Alizee", "SEBAT", "SEBAT", "avatar1"));
    }
    
    private void SetGroupList()
    {
        _groupList.Add(new Group(1UL, "Group 1", _playerList[0], _playerList[1], _playerList[2], _playerList[3], _playerList[4]));
        _groupList.Add(new Group(2UL, "Group 2", _playerList[1], _playerList[2], _playerList[3], _playerList[4], _playerList[5]));
        _groupList.Add(new Group(3UL, "Group 3", _playerList[2], _playerList[3], _playerList[4], _playerList[5], _playerList[6]));
        _groupList.Add(new Group(4UL, "Group 4", _playerList[3], _playerList[4], _playerList[5], _playerList[6], _playerList[7]));
        _groupList.Add(new Group(5UL, "Group 5", _playerList[4], _playerList[5], _playerList[6], _playerList[7], _playerList[8]));
        _groupList.Add(new Group(6UL, "Group 6", _playerList[5], _playerList[6], _playerList[7], _playerList[8], _playerList[9]));
        _groupList.Add(new Group(7UL, "Group 7", _playerList[6], _playerList[7], _playerList[8], _playerList[9], _playerList[10]));
        _groupList.Add(new Group(8UL, "Group 8", _playerList[7], _playerList[8], _playerList[9], _playerList[10], _playerList[11]));
        _groupList.Add(new Group(9UL, "Group 9", _playerList[8], _playerList[9], _playerList[10], _playerList[11], _playerList[12]));
        _groupList.Add(new Group(10UL, "Group 10", _playerList[9], _playerList[10], _playerList[11], _playerList[12], _playerList[13]));
        _groupList.Add(new Group(11UL, "Group 11", _playerList[10], _playerList[11], _playerList[12], _playerList[13], _playerList[14]));
        _groupList.Add(new Group(12UL, "Group 12", _playerList[11], _playerList[12], _playerList[13], _playerList[14], _playerList[15]));
    }
    
    private int GetRangeMin(int page, int pageSize)
    {
        return (page - 1) * pageSize;
    }
    
    private int GetRangeMax(int page, int pageSize)
    {
        return GetRangeMin(page, pageSize) + pageSize;
    }

    public Game? LoadGameByName(string name) => _gameList.FirstOrDefault(game => game.Name == name);

    public IEnumerable<Game> LoadGameByPlayer(Player player, int page, int pageSize)
    {
        var gameList = _gameList.Where(game => game.Players.Contains(player)).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }

    public IEnumerable<Game> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
    {
        var gameList = _gameList.Where(game => game.StartDate == startDate).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }

    public IEnumerable<Game> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
    {
        var gameList = _gameList.Where(game => game.EndDate == endDate).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }

    public IEnumerable<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page, int pageSize)
    {
        var gameList = _gameList.Where(game => game.StartDate >= startDate && game.EndDate <= endDate).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }

    public IEnumerable<Game> LoadGameByDateAndGroupInterval(DateTime startDate, DateTime endDate, Group group, int page, int pageSize)
    {
        var gameList = (from g in _groupList from player in g.Players from game in _gameList where game.Players.Contains(player) && game.StartDate >= startDate && game.EndDate <= endDate select game).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }
    
    public IEnumerable<Game> LoadGameByDateAndPlayerInterval(DateTime startDate, DateTime endDate, Player player, int page, int pageSize)
    {
        var gameList = _gameList.Where(game => game.StartDate >= startDate && game.EndDate <= endDate && game.Players.Contains(player)).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }
    
    public IEnumerable<Game> LoadGameByGroup(Group group, int page, int pageSize)
    {
        var gameList = (from g in _groupList from player in g.Players from game in _gameList where game.Players.Contains(player) select game).ToList();
        return gameList.GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));
    }
    
    public IEnumerable<Game> LoadAllGames(int page, int pageSize) => _gameList.ToList().GetRange(GetRangeMin(page, pageSize), GetRangeMax(page, pageSize));

    public IEnumerable<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page, int pageSize) => _playerList.Where(player => player.LastName == lastName && player.NickName == nickname).ToList();

    public IEnumerable<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page, int pageSize) => _playerList.Where(player => player.FirstName == firstName && player.NickName == nickname).ToList();

    public IEnumerable<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page, int pageSize) => _playerList.Where(player => player.FirstName == firstName && player.LastName == lastName).ToList();

    public IEnumerable<Player> LoadPlayerByNickname(string nickname, int page, int pageSize) => _playerList.Where(player => player.NickName == nickname).ToList();

    public IEnumerable<Player> LoadPlayerByLastName(string lastName, int page, int pageSize) => _playerList.Where(player => player.LastName == lastName).ToList();

    public IEnumerable<Player> LoadPlayerByFirstName(string firstName, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> LoadAllPlayer(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> LoadPlayersByGroup(Group group, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Group LoadGroupsByName(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Group> LoadAllGroups(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Group> LoadGroupsByPlayer(Player player, int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public IRules LoadRule(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IRules> LoadAllRules(int page, int pageSize)
    {
        throw new NotImplementedException();
    }
}
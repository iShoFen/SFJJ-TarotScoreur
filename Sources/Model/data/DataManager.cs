using Model.games;

namespace Model.data;

public class DataManager
{
    internal ILoader Loader { get; set; }
    internal ISaver Saver { get; set; }

    /// <summary>
    /// Constructor for the DataManager
    /// </summary>
    /// <param name="iLoader">Interface to load data</param>
    /// <param name="iSaver">Interface to save data</param>
    public DataManager(ILoader iLoader, ISaver iSaver)
    {
        Loader = iLoader;
        Saver = iSaver;
    }

    /*========== Players ==========*/
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    public void SavePlayer(Player player)
        => Saver.SavePlayer(player);

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadAllPlayer(int page, int pageSize)
        => Loader.LoadAllPlayer(page, pageSize);

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayersByGroup(Group group, int page, int pageSize)
        => Loader.LoadPlayersByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstName(string firstName, int page, int pageSize)
        => Loader.LoadPlayerByFirstName(firstName, page, pageSize);

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByLastName(string lastName, int page, int pageSize)
        => Loader.LoadPlayerByLastName(lastName, page, pageSize);

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByNickname(string nickname, int page, int pageSize)
        => Loader.LoadPlayerByNickname(nickname, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
        => Loader.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
        => Loader.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize);

    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page, int pageSize)
        => Loader.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize);
    /*========== End Players ==========*/


    /*========== Games ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public void SaveGame(Game game)
        => Saver.SaveGame(game);

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public Game? LoadGameByName(string name)
        => Loader.LoadGameByName(name);

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
        => Loader.LoadGameByStartDate(startDate, page, pageSize);

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
        => Loader.LoadGameByEndDate(endDate, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page, int pageSize)
        => Loader.LoadGameByDateInterval(startDate, endDate, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate, Group group, int page,
        int pageSize)
        => Loader.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate, Player player,
        int page, int pageSize)
        => Loader.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize);

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByPlayer(Player player, int page, int pageSize)
        => Loader.LoadGameByPlayer(player, page, pageSize);

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByGroup(Group group, int page, int pageSize)
        => Loader.LoadGameByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadAllGames(int page, int pageSize)
        => Loader.LoadAllGames(page, pageSize);
    /*========== End Games ==========*/


    /*========== Groups ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public void SaveGroup(Group group)
        => Saver.SaveGroup(group);

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public Group? LoadGroupsByName(string name)
        => Loader.LoadGroupsByName(name);

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public IEnumerable<Group> LoadAllGroups(int page, int pageSize)
        => Loader.LoadAllGroups(page, pageSize);

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public IEnumerable<Group> LoadGroupsByPlayer(Player player, int page, int pageSize)
        => Loader.LoadGroupsByPlayer(player, page, pageSize);
    /*========== End Groups ==========*/


    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    public IRules? LoadRule(string name)
        => Loader.LoadRule(name);

    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of rules</returns>
    public IEnumerable<IRules> LoadAllRules(int page, int pageSize)
        => Loader.LoadAllRules(page, pageSize);
    /*========== End Rules ==========*/

    /*========== Hand ==========*/
    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    public IEnumerable<KeyValuePair<int, Hand>> LoadHandByGame(Game game, int page, int pageSize)
        => Loader.LoadHandByGame(game, page, pageSize);
    /*========== End hand ==========*/
}
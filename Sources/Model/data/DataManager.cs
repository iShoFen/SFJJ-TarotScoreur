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
    public async Task<Player?> SavePlayer(Player player)
        => await Saver.SavePlayer(player);

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
        => await Loader.LoadAllPlayer(page, pageSize);

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
        => await Loader.LoadPlayersByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
        => await Loader.LoadPlayerByFirstName(firstName, page, pageSize);

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
        => await Loader.LoadPlayerByLastName(lastName, page, pageSize);

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
        => await Loader.LoadPlayerByNickname(nickname, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
        => await Loader.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
        => await Loader.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize);

    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
        int pageSize)
        => await Loader.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize);
    /*========== End Players ==========*/


    /*========== Games ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public async Task<Game?> SaveGame(Game game)
        => await Saver.SaveGame(game);

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public async Task<Game?> LoadGameByName(string name)
        => await Loader.LoadGameByName(name);

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
        => await Loader.LoadGameByStartDate(startDate, page, pageSize);

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
        => await Loader.LoadGameByEndDate(endDate, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize)
        => await Loader.LoadGameByDateInterval(startDate, endDate, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
        Group group, int page, int pageSize)
        => await Loader.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
        Player player, int page, int pageSize)
        => await Loader.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize);

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
        => await Loader.LoadGameByPlayer(player, page, pageSize);

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
        => await Loader.LoadGameByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize)
        => await Loader.LoadAllGames(page, pageSize);
    /*========== End Games ==========*/


    /*========== Groups ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public async Task<Group?> SaveGroup(Group group)
        => await Saver.SaveGroup(group);

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public async Task<Group?> LoadGroupsByName(string name)
        => await Loader.LoadGroupsByName(name);

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize)
        => await Loader.LoadAllGroups(page, pageSize);

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
        => await Loader.LoadGroupsByPlayer(player, page, pageSize);
    /*========== End Groups ==========*/

    /*========== Hand ==========*/
    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
        => await Loader.LoadHandByGame(game, page, pageSize);
    /*========== End hand ==========*/
}
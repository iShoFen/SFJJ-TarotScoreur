using Model.data;
using Model.enums;
using Model.games;

namespace Model;

public class Manager
{
    private readonly DataManager _dataManager;
    public Manager(ILoader iLoader, ISaver iSaver) => _dataManager = new DataManager(iLoader, iSaver);

    public void SetDataManager(ILoader iLoader, ISaver iSaver)
    {
        _dataManager.Loader = iLoader;
        _dataManager.Saver = iSaver;
    }

    /*========== Player ==========*/
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    public async Task<Player> SavePlayer(Player player) => await _dataManager.SavePlayer(player);

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadAllPlayer(int page, int pageSize)
        => await _dataManager.LoadAllPlayer(page, pageSize);

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayersByGroup(Group group, int page, int pageSize)
        => await _dataManager.LoadPlayersByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstName(string firstName, int page, int pageSize)
        => await _dataManager.LoadPlayerByFirstName(firstName, page, pageSize);

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByLastName(string lastName, int page, int pageSize)
        => await _dataManager.LoadPlayerByLastName(lastName, page, pageSize);

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int page, int pageSize)
        => await _dataManager.LoadPlayerByNickname(nickname, page, pageSize);

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
        => await _dataManager.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize);

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
        => await _dataManager.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize);

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
        => await _dataManager.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize);

    /// <summary>
    /// Method to create a player
    /// </summary>
    /// <param name="firstName">FirstName of the player</param>
    /// <param name="lastName">LastName of the player</param>
    /// <param name="nickname">Nickname of the player</param>
    /// <param name="avatar">Avatar of the player</param>
    /// <returns>The player created</returns>
    public Player CreatePlayer(string firstName, string lastName, string nickname, string avatar) =>
        new(firstName, lastName, nickname, avatar);
    /*========== End player ==========*/


    /*========== Game ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public async Task<Game> SaveGame(Game game) => await _dataManager.SaveGame(game);

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public async Task<Game?> LoadGameByName(string name) => await _dataManager.LoadGameByName(name);

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
        => await _dataManager.LoadGameByStartDate(startDate, page, pageSize);

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
        => await _dataManager.LoadGameByEndDate(endDate, page, pageSize);

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize) =>
        await _dataManager.LoadGameByDateInterval(startDate, endDate, page, pageSize);

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
        Group group, int page,
        int pageSize)
        => await _dataManager.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize);

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
        => await _dataManager.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize);

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByPlayer(Player player, int page, int pageSize)
        => await _dataManager.LoadGameByPlayer(player, page, pageSize);

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadGameByGroup(Group group, int page, int pageSize)
        => await _dataManager.LoadGameByGroup(group, page, pageSize);

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>> LoadAllGames(int page, int pageSize) =>
        await _dataManager.LoadAllGames(page, pageSize);

    /// <summary>
    /// Method to create a game
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <param name="rules">Rules of the game</param>
    /// <param name="startDate">Start date of the game</param>
    /// <returns>The game created</returns>
    public Game CreateGame(string name, IRules rules, DateTime startDate) => new Game(name, rules, startDate);
    /*========== End game ==========*/

    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    public async Task<IRules?> LoadRule(string name) => await _dataManager.LoadRule(name);

    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of rules</returns>
    public async Task<IEnumerable<IRules>> LoadAllRules(int page, int pageSize) =>
        await _dataManager.LoadAllRules(page, pageSize);
    /*========== End rules ==========*/

    /*========== Group ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public async Task<Group> SaveGroup(Group group) => await _dataManager.SaveGroup(group);

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public async Task<Group?> LoadGroupsByName(string name) => await _dataManager.LoadGroupsByName(name);

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadAllGroups(int page, int pageSize) =>
        await _dataManager.LoadAllGroups(page, pageSize);

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>> LoadGroupsByPlayer(Player player, int page, int pageSize)
        => await _dataManager.LoadGroupsByPlayer(player, page, pageSize);

    /// <summary>
    /// Method to create a group
    /// </summary>
    /// <param name="name">Name of the group</param>
    /// <returns>The group created</returns>
    public Group CreateGroup(string name) => new Group(name);
    /*========== End group ==========*/

    /*========== Hand ==========*/
    /// <summary>
    /// Method to create a hand
    /// </summary>
    /// <param name="id">The unique identifier for the hand</param>
    /// <param name="handNumber"> The number of the hand </param>
    /// <param name="rules"> The Rules of the game applied to this hand </param>
    /// <param name="date"> The date of the hand </param>
    /// <param name="takerScore"> The score of the taker </param>
    /// <param name="twentyOne"> Indicates if the taker as the twenty one oudler </param>
    /// <param name="excuse"> Indicates if the taker as the excuse oudler </param>
    /// <param name="petit"> Indicates the state of the Petit related to the taker </param>
    /// <param name="chelem">Indicates tje state of the Chelem related to the taker</param>
    /// <param name="biddings"> Players bidding details </param>
    /// <returns>The hand created</returns>
    public Hand CreateHand(ulong id, int handNumber, IRules rules, DateTime date, int takerScore, bool? twentyOne,
        bool? excuse, PetitResult petit, Chelem chelem, params KeyValuePair<Player, (Bidding, Poignee)>[] biddings)
        => new Hand(id, handNumber, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings);

    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>> LoadHandByGame(Game game, int page, int pageSize)
        => await _dataManager.LoadHandByGame(game, page, pageSize);
    /*========== End hand ==========*/
}
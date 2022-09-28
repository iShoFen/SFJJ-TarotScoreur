using System.Collections.ObjectModel;
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
    public void SavePlayer(Player player) => _dataManager.SavePlayer(player);

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadAllPlayer() => _dataManager.LoadAllPlayer();

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayersByGroup(Group group) => _dataManager.LoadPlayersByGroup(group);

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstName(string firstName) =>
        _dataManager.LoadPlayerByFirstName(firstName);

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByLastName(string lastName) =>
        _dataManager.LoadPlayerByLastName(lastName);

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByNickname(string nickname) =>
        _dataManager.LoadPlayerByNickname(nickname);

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName) =>
        _dataManager.LoadPlayerByFirstNameAndLastName(firstName, lastName);

    /// <summary>
    /// Method to load a player by firstname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname) =>
        _dataManager.LoadPlayerByFirstNameAndNickname(firstName, nickname);

    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <returns>List of players</returns>
    public IEnumerable<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname) =>
        _dataManager.LoadPlayerByLastNameAndNickname(lastName, nickname);

    /// <summary>
    /// Method to create a player
    /// </summary>
    /// <param name="firstName">FirstName of the player</param>
    /// <param name="lastName">LastName of the player</param>
    /// <param name="nickname">Nickname of the player</param>
    /// <param name="avatar">Avatar of the player</param>
    /// <returns>The player created</returns>
    public Player CreatePlayer(string firstName, string lastName, string nickname, string avatar) =>
        new Player(firstName, lastName, nickname, avatar);
    /*========== End player ==========*/


    /*========== Game ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public void SaveGame(Game game) => _dataManager.SaveGame(game);

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public Game LoadGameByName(string name) => _dataManager.LoadGameByName(name);

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByStartDate(DateTime startDate) =>
        _dataManager.LoadGameByStartDate(startDate);

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByEndDate(DateTime endDate) => _dataManager.LoadGameByEndDate(endDate);

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate) =>
        _dataManager.LoadGameByDateInterval(startDate, endDate);

    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByDateAndGroupInterval(DateTime startDate, DateTime endDate, Group group) =>
        _dataManager.LoadGameByDateAndGroupInterval(startDate, endDate, group);

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game>
        LoadGameByDateAndPlayerInterval(DateTime startDate, DateTime endDate, Player player) =>
        _dataManager.LoadGameByDateAndPlayerInterval(startDate, endDate, player);

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByPlayer(Player player) => _dataManager.LoadGameByPlayer(player);

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadGameByGroup(Group group) => _dataManager.LoadGameByGroup(group);

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <returns>List of games</returns>
    public IEnumerable<Game> LoadAllGames() => _dataManager.LoadAllGames();

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
    public IRules LoadRule(string name) => _dataManager.LoadRule(name);

    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <returns>List of rules</returns>
    public IEnumerable<IRules> LoadAllRules() => _dataManager.LoadAllRules();
    /*========== End rules ==========*/

    /*========== Group ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public void SaveGroup(Group group) => _dataManager.SaveGroup(group);

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public Group LoadGroupsByName(string name) => _dataManager.LoadGroupsByName(name);

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <returns>List of groups</returns>
    public IEnumerable<Group> LoadAllGroups() => _dataManager.LoadAllGroups();

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of groups</returns>
    public IEnumerable<Group> LoadGroupsByPlayer(Player player) => _dataManager.LoadGroupsByPlayer(player);

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
        bool? excuse, PetitResult petit, Chelem chelem, params KeyValuePair<Player, (Bidding, Poignee)>[] biddings) =>
        new Hand(id, handNumber, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings);
    /*========== End hand ==========*/
}
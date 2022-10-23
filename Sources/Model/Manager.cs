using System.Globalization;
using Model.data;
using Model.enums;
using Model.games;
using NLog;

namespace Model;

public class Manager
{
    private readonly DataManager _dataManager;
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public Manager(ILoader iLoader, ISaver iSaver)
    {
        try
        {
            _dataManager = new DataManager(iLoader, iSaver);
            _logger.Info("Manager created");
        }
        catch(Exception e)
        {
            _logger.Error("Manager creation error | {arguments}",e.Message );
        }
    }

    public void SetDataManager(ILoader iLoader, ISaver iSaver)
    {
        try
        {
            _dataManager.Loader = iLoader;
            _dataManager.Saver = iSaver;
            _logger.Info("DataManager set");
        }
        catch(Exception e)
        {
            _logger.Error("Set data manager error | {arguments}", e.Message);
        }
    }

    /*========== Player ==========*/
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    public async Task<Player?> SavePlayer(Player player)
    {
        try
        {
            var playerSaved = await _dataManager.SavePlayer(player);
            _logger.Info("Player saved : {arguments}", player.ToString());
            return playerSaved;
        }
        catch(Exception e)
        {
            _logger.Error("Save player error | {arguments}", e.Message);
            return null;
        }
    }

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadAllPlayer(int page, int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadAllPlayer(page, pageSize);
            _logger.Info("All players loaded");
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Load all players error | {arguments}", e.Message);
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayersByGroup(Group group, int page, int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayersByGroup(group, page, pageSize);
            _logger.Info("Players loaded by group : {arguments}", group.ToString());
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Load players by group error : {group}| {arguments}", group.Id, e.Message);
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByFirstName(string firstName, int page, int pageSize)
    {
        try
        {
             var players = await _dataManager.LoadPlayerByFirstName(firstName, page, pageSize);
            _logger.Info("Player loaded by FirstName : {arguments}", firstName);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by FirstName : {firstname} | {arguments}", firstName, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByLastName(string lastName, int page, int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayerByLastName(lastName, page, pageSize);
            _logger.Info("Player loaded by LastName : {arguments}", lastName);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by LastName : {lastname} | {arguments}", lastName, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByNickname(string nickname, int page, int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayerByNickname(nickname, page, pageSize);
            _logger.Info("Player loaded by Nickname : {arguments}", nickname);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by Nickname : {nickname} | {arguments}", nickname, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page,
        int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayerByFirstNameAndLastName(firstName, lastName, page, pageSize);
            _logger.Info("Player loaded by FirstName and LastName : {arguments} {arguments}", firstName, lastName);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by FirstName and LastName : {arguments} {arguments} | {arguments}", firstName, lastName, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by firstname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page,
        int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayerByFirstNameAndNickname(firstName, nickname, page, pageSize);
            _logger.Info("Player loaded by FirstName and Nickname : {arguments} {arguments}", firstName, nickname);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by FirstName and Nickname : {arguments} {arguments} | {arguments}", firstName, nickname, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page,
        int pageSize)
    {
        try
        {
            var players = await _dataManager.LoadPlayerByLastNameAndNickname(lastName, nickname, page, pageSize);
            _logger.Info("Player loaded by LastName and Nickname : {arguments} {arguments}", lastName, nickname);
            return players;
        }
        catch(Exception e)
        {
            _logger.Error("Error player loaded by LastName and Nickname : {lastname} {nickname} | {arguments}", lastName, nickname, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to create a player
    /// </summary>
    /// <param name="firstName">FirstName of the player</param>
    /// <param name="lastName">LastName of the player</param>
    /// <param name="nickname">Nickname of the player</param>
    /// <param name="avatar">Avatar of the player</param>
    /// <returns>The player created</returns>
    public Player? CreatePlayer(string firstName, string lastName, string nickname, string avatar)
    {
        try
        {
            var player = new Player(firstName, lastName, nickname, avatar);
            _logger.Info("Player created : {arguments}", player.ToString());
            return player;
        }
        catch(Exception e)
        {
            _logger.Error("Error player created : {arguments} | {arguments}", firstName, e.Message );
            return null;
        }
    }
    
    /*========== End player ==========*/


    /*========== Game ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public async Task<Game?> SaveGame(Game game)
    {
        try
        {
            var gameSaved = await _dataManager.SaveGame(game);
            _logger.Info("Game saved : {arguments}", game.ToString());
            return gameSaved;
        }
        catch(Exception e)
        {
            _logger.Error("Error game saved : {arguments} | {arguments}", game.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public async Task<Game?> LoadGameByName(string name)
    {
        try
        {
            var games = await _dataManager.LoadGameByName(name);
            _logger.Info("Game loaded by name : {arguments}", name);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by name : {arguments} | {arguments}", name, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByStartDate(DateTime startDate, int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByStartDate(startDate, page, pageSize);
            _logger.Info("Game loaded by start date : {arguments}", startDate);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by start date : {arguments} | {arguments}", startDate, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByEndDate(DateTime endDate, int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByEndDate(endDate, page, pageSize);
            _logger.Info("Game loaded by end date : {arguments}", endDate);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by end date : {arguments} | {arguments}", endDate, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page,
        int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByDateInterval(startDate, endDate, page, pageSize);
            _logger.Info("Game loaded by date interval : {arguments} {arguments}", startDate, endDate);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by date interval : {arguments} {arguments} | {arguments}", startDate, endDate, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,
        Group group, int page,
        int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByDateIntervalAndGroup(startDate, endDate, group, page, pageSize);
            _logger.Info("Game loaded by date interval and group : {arguments} {arguments} {arguments}", group.ToString(), startDate, endDate);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by date interval and group : {arguments} {arguments} {arguments} | {arguments}", startDate, endDate, group.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,
        Player player, int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByDateIntervalAndPlayer(startDate, endDate, player, page, pageSize);
            _logger.Info("Game loaded by date interval and player : {arguments} {arguments} {arguments}", player.ToString(), startDate, endDate);
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by date interval and player : {arguments} {arguments} {arguments} | {arguments}", startDate, endDate, player.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByPlayer(Player player, int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByPlayer(player, page, pageSize);
            _logger.Info("Game loaded by player : {arguments}", player.ToString());
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by player : {arguments} | {arguments}", player.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByGroup(Group group, int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadGameByGroup(group, page, pageSize);
            _logger.Info("Game loaded by group : {arguments}", group.ToString());
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded by group : {arguments} | {arguments}", group.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadAllGames(int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadAllGames(page, pageSize);
            _logger.Info("All games loaded");
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error game loaded : {arguments}", e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to create a game
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <param name="rules">Rules of the game</param>
    /// <param name="startDate">Start date of the game</param>
    /// <returns>The game created</returns>
    public Game? CreateGame(string name, IRules rules, DateTime startDate)
    {
        try
        {
            var game = new Game(name, rules, startDate);
            _logger.Info("Game created : {arguments}", game.ToString());
            return game;
        }
        catch(Exception e)
        {
            _logger.Error("Error game created : {arguments} | {arguments}", name, e.Message );
            return null;
        }
    }
    /*========== End game ==========*/

    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    public async Task<IRules?> LoadRule(string name)
    {
        try
        {
            var rule = await _dataManager.LoadRule(name);
            _logger.Info("Rule loaded : {arguments}", name);
            return rule;
        }
        catch(Exception e)
        {
            _logger.Error("Error rule loaded : {arguments} | {arguments}", name, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of rules</returns>
    public async Task<IEnumerable<IRules>?> LoadAllRules(int page, int pageSize)
    {
        try
        {
            var rules = await _dataManager.LoadAllRules(page, pageSize);
            _logger.Info("All rules loaded");
            return rules;
        }
        catch(Exception e)
        {
            _logger.Error("Error rules loaded : {arguments}", e.Message );
            return null;
        }
    }
    /*========== End rules ==========*/

    /*========== Group ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public async Task<Group?> SaveGroup(Group group)
    {
        try
        {
            var groupSave = await _dataManager.SaveGroup(group);
            _logger.Info("Group saved : {arguments}", group.ToString());
            return groupSave;
        }
        catch(Exception e)
        {
            _logger.Error("Error group saved : {arguments} | {arguments}", group.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public async Task<Group?> LoadGroupsByName(string name)
    {
        try
        {
            var group = await _dataManager.LoadGroupsByName(name);
            _logger.Info("Group loaded by name : {arguments}", group.ToString());
            return group;
        }
        catch(Exception e)
        {
            _logger.Error("Error group loaded by name : {arguments} | {arguments}", name, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>?> LoadAllGroups(int page, int pageSize)
    {
        try
        {
            var games = await _dataManager.LoadAllGroups(page, pageSize);
            _logger.Info("All groups loaded");
            return games;
        }
        catch(Exception e)
        {
            _logger.Error("Error groups loaded : {arguments}", e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>?> LoadGroupsByPlayer(Player player, int page, int pageSize)
    {
        try
        {
            var groups = await _dataManager.LoadGroupsByPlayer(player, page, pageSize);
            _logger.Info("Groups loaded by player : {arguments}", player.ToString());
            return groups;
        }
        catch(Exception e)
        {
            _logger.Error("Error groups loaded by player : {arguments} | {arguments}", player.ToString(), e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to create a group
    /// </summary>
    /// <param name="name">Name of the group</param>
    /// <returns>The group created</returns>
    public Group? CreateGroup(string name)
    {
        try
        {
            var group = new Group(name);
            _logger.Info("Group created : {arguments}", group.ToString());
            return group;
        }
        catch(Exception e)
        {
            _logger.Error("Error group created : {arguments} | {arguments}", name, e.Message );
            return null;
        }
    }
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
    public Hand? CreateHand(ulong id, int handNumber, IRules rules, DateTime date, int takerScore, bool? twentyOne,
        bool? excuse, PetitResult petit, Chelem chelem, params KeyValuePair<Player, (Bidding, Poignee)>[] biddings)
    {
        try
        {
            var hand = new Hand(id, handNumber, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings);
            _logger.Info("Hand created : {arguments}", hand.ToString());
            return hand;
        }
        catch(Exception e)
        {
            _logger.Error("Error hand created : {arguments} | {arguments}", id, e.Message );
            return null;
        }
    }

    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>?> LoadHandByGame(Game game, int page, int pageSize)
    {
        try
        {
            var hands = await _dataManager.LoadHandByGame(game, page, pageSize);
            _logger.Info("Hands loaded by game : {arguments}", game.ToString());
            return hands;
        }
        catch(Exception e)
        {
            _logger.Error("Error hands loaded by game : {arguments} | {arguments}", game.ToString(), e.Message );
            return null;
        }
    }
    /*========== End hand ==========*/
}
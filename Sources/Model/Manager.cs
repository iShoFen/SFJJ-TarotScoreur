using Model.Data;
using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;
using NLog;

namespace Model;

public partial class Manager
{
    /// <summary>
    /// IReader from read methods (select)
    /// </summary>
    private IReader _reader;

    /// <summary>
    /// IWriter for write methods (create, update, delete)
    /// </summary>
    private IWriter _writer;

    /// <summary>
    /// 
    /// </summary>
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Instantiate a new Manager with IReader and IWriter interfaces 
    /// </summary>
    /// <param name="reader">IReader to use in the Manager</param>
    /// <param name="writer">IWriter to use in the Manager</param>
    public Manager(IReader reader, IWriter writer)
    {
        _reader = reader;
        _writer = writer;
        _logger.Info("Instantiate Manager");
    }

    /// <summary>
    /// Set the new Reader to use when read methods (select) are called.
    /// </summary>
    /// <param name="reader">New reader</param>
    /// <returns>Instance of Manager for chaining methods</returns>
    public Manager SetReader(IReader reader)
    {
        _reader = reader;
        _logger.Info("Set Loader in DataManager");
        return this;
    }

    /// <summary>
    /// Set the new Writer to use when write methods (create, update, delete) are called.
    /// </summary>
    /// <param name="writer">New writer</param>
    /// <returns>Instance of Manager for chaining methods</returns>
    public Manager SetWriter(IWriter writer)
    {
        _writer = writer;
        _logger.Info("Set Saver in DataManager");
        return this;
    }

    /*========== Player ==========*/
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    public async Task<Player?> SavePlayer(Player player)
    {
        var playerSaved = await _writer.SavePlayer(player);
        _logger.Info("Player saved : {arguments}", player.ToString());
        return playerSaved;
    }

    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="start"> Number of the page to load</param>
    /// <param name="count">Size of the page</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadAllPlayer(int start, int count)
    {
        var players = await _reader.GetPlayers(start, count);
        _logger.Info("All players loaded");
        return players;
    }

    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>?> LoadPlayersByGroup(Group group)
    {
        var players = await _reader.GetPlayersByGroup(group.Id);
        _logger.Info("Players loaded by group : {arguments}", group.ToString());
        return players;
    }

    public async Task<IEnumerable<Player>> LoadPlayersByPattern(string pattern, int start, int count)
    {
        var players = await _reader.GetPlayersByPattern(pattern, start, count);
        _logger.Info("Player loaded by pattern: {arguments}", pattern);
        return players;
    }

    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">nickname to search</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByNickname(string nickname, int start, int count)
    {
        var players = await _reader.GetPlayersByNickname(nickname, start, count);
        _logger.Info("Player loaded by Nickname : {arguments}", nickname);
        return players;
    }

    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>List of players</returns>
    public async Task<IEnumerable<Player>> LoadPlayerByFirstNameAndLastName(string pattern, int start,
        int count)
    {
        var players = await _reader.GetPlayersByFirstNameAndLastName(pattern, start, count);
        _logger.Info("Player loaded by Pattern : {arguments} {arguments}");
        return players;
    }

    /*========== End player ==========*/


    /*========== Game ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public async Task<Game?> SaveGame(Game game)
    {
        var gameSaved = await _writer.SaveGame(game);
        _logger.Info("Game saved : {arguments}", game.ToString());
        return gameSaved;
    }

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="pattern">Name of the game</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>A game</returns>
    public async Task<IEnumerable<Game>> LoadGameByName(string pattern, int start, int count)
    {
        var games = await _reader.GetGamesByName(pattern, start, count);
        _logger.Info("Game loaded by name : {arguments}", pattern);
        return games;
    }

    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int start,
        int count)
    {
        var games = await _reader.GetGamesByDate(startDate, endDate, start, count);
        _logger.Info("Game loaded by date interval : {arguments} {arguments}", startDate, endDate);
        return games;
    }

    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadGameByPlayer(Player player, int start, int count)
    {
        var games = await _reader.GetGamesByPlayer(player.Id, start, count);
        _logger.Info("Game loaded by player : {arguments}", player.ToString());
        return games;
    }

    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="start"> Number of the page to load</param>
    /// <param name="count">Size of the page</param>
    /// <returns>List of games</returns>
    public async Task<IEnumerable<Game>?> LoadAllGames(int start, int count)
    {
        var games = await _reader.GetGames(start, count);
        _logger.Info("All games loaded");
        return games;
    }
    /*========== End game ==========*/


    /*========== Group ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public async Task<Group?> SaveGroup(Group group)
    {
        var groupSave = await _writer.SaveGroup(group);
        _logger.Info("Group saved : {arguments}", group.ToString());
        return groupSave;
    }

    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>A group</returns>
    public async Task<IEnumerable<Group>> LoadGroupsByName(string name, int start, int count)
    {
        var group = await _reader.GetGroupsByName(name, start, count);
        _logger.Info("Group loaded by name : {arguments}", name);
        return group;
    }

    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="start"> Number of the page to load</param>
    /// <param name="count">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>?> LoadAllGroups(int start, int count)
    {
        var games = await _reader.GetGroups(start, count);
        _logger.Info("All groups loaded");
        return games;
    }

    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="start"> Number of the page to load</param>
    /// <param name="count">Size of the page</param>
    /// <returns>List of groups</returns>
    public async Task<IEnumerable<Group>?> LoadGroupsByPlayer(Player player, int start, int count)
    {
        var groups = await _reader.GetGroupsByPlayer(player.Id, start, count);
        _logger.Info("Groups loaded by player : {arguments}", player.ToString());
        return groups;
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
    public Hand CreateHand(ulong id, int handNumber, IRules rules, DateTime date, int takerScore, bool? twentyOne,
        bool? excuse, PetitResults petit, Chelem chelem, params KeyValuePair<Player, (Biddings, Poignee)>[] biddings)
    {
        var hand = new Hand(id, handNumber, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings);
        _logger.Info("Hand created : {arguments}", hand.ToString());
        return hand;
    }

    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>List of hands</returns>
    public async Task<IEnumerable<KeyValuePair<int, Hand>>?> LoadHandByGame(Game game, int start, int count)
    {
        var hands = await _reader.GetHandsByGame(game.Id, start, count);
        _logger.Info("Hands loaded by game : {arguments}", game.ToString());
        return hands;
    }
    /*========== End hand ==========*/
}
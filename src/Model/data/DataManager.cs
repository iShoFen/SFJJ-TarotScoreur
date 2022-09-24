using System.Collections.ObjectModel;
using Model.enums;

namespace Model.data;

public class DataManager
{
    private ILoad iLoad;
    private ISave iSave;
    
    /// <summary>
    /// Constructor for the DataManager
    /// </summary>
    /// <param name="iLoad">Interface to load data</param>
    /// <param name="iSave">Interface to save data</param>
    public DataManager(ILoad iLoad , ISave iSave)
    {
        this.iLoad = iLoad;
        this.iSave = iSave;
    }

    /*========== Players ==========*/
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    public void SavePlayer(Player player) => iSave.SavePlayer(player);
    
    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadAllPlayer() => iLoad.LoadAllPlayer();
    
    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayersByGroup(Group group) => iLoad.LoadPlayersByGroup(group);
    
    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByFirstName(string firstName) => iLoad.LoadPlayerByFirstName(firstName);
    
    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByLastName(string lastName) => iLoad.LoadPlayerByLastName(lastName);
    
    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickName">Nickname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByNickName(string nickName) => iLoad.LoadPlayerByNickName(nickName);
    
    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName) => iLoad.LoadPlayerByFirstNameAndLastName(firstName, lastName);
    
    /// <summary>
    /// Method to load a player by firtsname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickName) => iLoad.LoadPlayerByFirstNameAndNickname(firstName, nickName);
    
    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <returns>List of players</returns>
    public ReadOnlyCollection<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickName) => iLoad.LoadPlayerByLastNameAndNickname(lastName, nickName);
    /*========== End Players ==========*/
    
    
    /*========== Games ==========*/
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    public void SaveGame(Game game) => iSave.SaveGame(game);

    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    public Game LoadGameByName(string name) => iLoad.LoadGameByName(name);

    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByStartDate(DateTime startDate) => iLoad.LoadGameByStartDate(startDate);
    
    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByEndDate(DateTime endDate) => iLoad.LoadGameByEndDate(endDate);
    
    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate) => iLoad.LoadGameByDateInterval(startDate, endDate);
    
    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByDateAndGroupInterval(DateTime startDate, DateTime endDate, Group group) => iLoad.LoadGameByDateAndGroupInterval(startDate, endDate, group);

    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByDateAndPlayerInterval(DateTime startDate, DateTime endDate, Player player) => iLoad.LoadGameByDateAndPlayerInterval(startDate, endDate, player);
    
    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByPlayer(Player player) => iLoad.LoadGameByPlayer(player);
    
    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadGameByGroup(Group group) => iLoad.LoadGameByGroup(group);
    
    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <returns>List of games</returns>
    public ReadOnlyCollection<Game> LoadAllGames() => iLoad.LoadAllGames();
    /*========== End Games ==========*/
    
    
    /*========== Groups ==========*/
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    public void SaveGroup(Group group) => iSave.SaveGroup(group);
    
    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    public Group LoadGroupsByName(string name) => iLoad.LoadGroupsByName(name);
    
    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <returns>List of groups</returns>
    public ReadOnlyCollection<Group> LoadAllGroups() => iLoad.LoadAllGroups();
    
    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of groups</returns>
    public ReadOnlyCollection<Group> LoadGroupsByPlayer(Player player) => iLoad.LoadGroupsByPlayer(player);
    /*========== End Groups ==========*/
    
    
    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    public IRules LoadRule(string name) => iLoad.LoadRule(name);
    
    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <returns>List of rules</returns>
    public ReadOnlyCollection<IRules> LoadAllRules() =>iLoad.LoadAllRules();
    /*========== End Rules ==========*/
}
using System.Collections.ObjectModel;
using Model.enums;

namespace Model.data;

public interface ILoad
{
    /*========== Games ==========*/
    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    Game LoadGameByName(string name);
    
    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByPlayer(Player player);
    
    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByStartDate(DateTime startDate);
    
    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByEndDate(DateTime endDate);
    
    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate);
    
    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByDateAndGroupInterval(DateTime startDate, DateTime endDate,Group group);
    
    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByDateAndPlayerInterval(DateTime startDate, DateTime endDate,Player player);
    
    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadGameByGroup(Group group);
    
    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <returns>List of games</returns>
    ReadOnlyCollection<Game> LoadAllGames();
    /*========== End Games ==========*/
    
    
    /*========== Players ==========*/
    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname);
    
    /// <summary>
    /// Method to load a player by firtsname and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname);
    
    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName);
    
    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickName">Nickname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByNickName(string nickName);
    
    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByLastName(string lastName);
    
    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayerByFirstName(string firstName);
    
    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadAllPlayer();
    
    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <returns>List of players</returns>
    ReadOnlyCollection<Player> LoadPlayersByGroup(Group group);
    /*========== End Players ==========*/
    
    
    /*========== Groups ==========*/
    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    Group LoadGroupsByName(string name);
    
    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <returns>List of groups</returns>
    ReadOnlyCollection<Group> LoadAllGroups();
    
    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <returns>List of groups</returns>
    ReadOnlyCollection<Group> LoadGroupsByPlayer(Player player);
    /*========== End Groups ==========*/
    
    
    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    IRules LoadRule(string name);
    
    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <returns>List of rules</returns>
    ReadOnlyCollection<IRules> LoadAllRules();
    /*========== End Rules ==========*/
}
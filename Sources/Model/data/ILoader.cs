using Model.games;

namespace Model.data;

public interface ILoader
{
    /*========== Games ==========*/
    /// <summary>
    /// Method to load a game by name
    /// </summary>
    /// <param name="name">Name of the game</param>
    /// <returns>A game</returns>
    Game? LoadGameByName(string name);
    
    /// <summary>
    /// Method to load games by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByPlayer(Player player, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by start date
    /// </summary>
    /// <param name="startDate">Start date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByStartDate(DateTime startDate, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by end date
    /// </summary>
    /// <param name="endDate">End date of games</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByEndDate(DateTime endDate, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by an interval of dates
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByDateInterval(DateTime startDate, DateTime endDate, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by an interval of dates and a group
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByDateIntervalAndGroup(DateTime startDate, DateTime endDate,Group group, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by an interval of dates and a player
    /// </summary>
    /// <param name="startDate">Start date of the interval</param>
    /// <param name="endDate">End date of the interval</param>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByDateIntervalAndPlayer(DateTime startDate, DateTime endDate,Player player, int page, int pageSize);
    
    /// <summary>
    /// Method to load games by a group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadGameByGroup(Group group, int page, int pageSize);
    
    /// <summary>
    /// Method to load all games
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of games</returns>
    IEnumerable<Game> LoadAllGames(int page, int pageSize);
    /*========== End Games ==========*/
    
    
    /*========== Players ==========*/
    /// <summary>
    /// Method to load a player by lastname and nickname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByLastNameAndNickname(string lastName, string nickname, int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by firstName and nickname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="nickname">Nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByFirstNameAndNickname(string firstName, string nickname, int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by firstname and lastname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByFirstNameAndLastName(string firstName, string lastName, int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by nickname
    /// </summary>
    /// <param name="nickname">Nickname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByNickname(string nickname, int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by lastname
    /// </summary>
    /// <param name="lastName">Lastname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByLastName(string lastName, int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by firstname
    /// </summary>
    /// <param name="firstName">Firstname to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadPlayerByFirstName(string firstName, int page, int pageSize);
    
    /// <summary>
    /// Method to load all players
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player> LoadAllPlayer(int page, int pageSize);
    
    /// <summary>
    /// Method to load a player by group
    /// </summary>
    /// <param name="group">Group to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of players</returns>
    IEnumerable<Player>? LoadPlayersByGroup(Group group, int page, int pageSize);
    /*========== End Players ==========*/
    
    
    /*========== Groups ==========*/
    /// <summary>
    /// Method to load a group by name
    /// </summary>
    /// <param name="name">Name to search</param>
    /// <returns>A group</returns>
    Group? LoadGroupsByName(string name);
    
    /// <summary>
    /// Method to load all groups
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    IEnumerable<Group> LoadAllGroups(int page, int pageSize);
    
    /// <summary>
    /// Method to load a group by player
    /// </summary>
    /// <param name="player">Player to search</param>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of groups</returns>
    IEnumerable<Group> LoadGroupsByPlayer(Player player, int page, int pageSize);
    /*========== End Groups ==========*/
    
    
    /*========== Rules ==========*/
    /// <summary>
    /// Method to load a rule by name
    /// </summary>
    /// <param name="name">Name of the rule to search</param>
    /// <returns>A IRules</returns>
    IRules? LoadRule(string name);
    
    /// <summary>
    /// Method to load all rules
    /// </summary>
    /// <param name="page"> Number of the page to load</param>
    /// <param name="pageSize">Size of the page</param>
    /// <returns>List of rules</returns>
    IEnumerable<IRules> LoadAllRules(int page, int pageSize);
    /*========== End Rules ==========*/
    
    /*========== Hands ==========*/
    /// <summary>
    /// Method to load hands by game
    /// </summary>
    /// <param name="game"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <returns>List of hands</returns>
    IEnumerable<KeyValuePair<int, Hand>> LoadHandByGame(Game game, int page, int pageSize);
    /*========== End Hands ==========*/
}
using Model.Enums;
using Model.Games;
using Model.Players;
using Model.Rules;

namespace Model;

public partial class Manager
{
    #region Player

    /// <summary>
    /// Get players with the pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players paginated</returns>
    public async Task<IEnumerable<Player>> GetPlayers(int start, int count)
    {
        var players = await _reader.GetPlayers(start, count);
        _logger.Info("All players loaded");
        
        return players;
    }

    /// <summary>
    /// Get the player corresponding to the id.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <returns>Player corresponding to the id or null it does not exist.</returns>
    public async Task<Player?> GetPlayerById(ulong playerId)
    {
        var player = await _reader.GetPlayerById(playerId);
        
        if(player is null) _logger.Warn($"Player with id {playerId} not found");
        else _logger.Info($"Player with id {playerId} loaded");

        return player;
    }

    /// <summary>
    /// Get players by searching on firstname, lastname, and nickname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count)
    {
        var players = await _reader.GetPlayersByPattern(pattern, start, count);
        _logger.Info($"Players filtered with pattern {pattern} loaded");
        
        return players;
    }

    /// <summary>
    /// Get players by searching on nickname field with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count)
    {
        var players = await _reader.GetPlayersByNickname(pattern, start, count);
        _logger.Info($"Players filtered with nickname {pattern} loaded");
        
        return players;
    }

    /// <summary>
    /// Get players by searching on firstname and lastname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count)
    {
        var players = await _reader.GetPlayersByFirstNameAndLastName(pattern, start, count);
        _logger.Info($"Players filtered with firstname and lastname {pattern} loaded");
        
        return players;
    }

    #endregion
    
    #region User
    
    /// <summary>
    /// Get users with the pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of users to return</param>
    /// <returns>List of users paginated</returns>
    public async Task<IEnumerable<User>> GetUsers(int start, int count)
    {
        var users = await _reader.GetUsers(start, count);
        _logger.Info("All users loaded");
        
        return users;
    }

    /// <summary>
    /// Get the user corresponding to the id.
    /// </summary>
    /// <param name="userId">Id of the user to search</param>
    /// <returns>User corresponding to the id or null it does not exist.</returns>
    public async Task<User?> GetUserById(ulong userId)
    {
        var user = await _reader.GetUserById(userId);
        
        if(user is null) _logger.Warn($"User with id {userId} not found");
        else _logger.Info($"User with id {userId} loaded");

        return user;
    }

    /// <summary>
    /// Get users by searching on firstname, lastname, and nickname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of users to return</param>
    /// <returns>List of users filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<User>> GetUsersByPattern(string pattern, int start, int count)
    {
        var users = await _reader.GetUsersByPattern(pattern, start, count);
        _logger.Info($"Users filtered with pattern {pattern} loaded");
        
        return users;
    }

    /// <summary>
    /// Get users by searching on nickname field with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of users to return</param>
    /// <returns>List of users filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<User>> GetUsersByNickname(string pattern, int start, int count)
    {
        var users = await _reader.GetUsersByNickname(pattern, start, count);
        _logger.Info($"Users filtered with nickname {pattern} loaded");
        
        return users;
    }

    /// <summary>
    /// Get users by searching on firstname and lastname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of users to return</param>
    /// <returns>List of users filtered with the pattern and pagination</returns>
    public async Task<IEnumerable<User>> GetUsersByFirstNameAndLastName(string pattern, int start, int count)
    {
        var users = await _reader.GetUsersByFirstNameAndLastName(pattern, start, count);
        _logger.Info($"Users filtered with firstname and lastname {pattern} loaded");
        
        return users;
    }
    
    #endregion
    
    #region Group

    /// <summary>
    /// Get groups with pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups paginated</returns>
    public async Task<IEnumerable<Group>> GetGroups(int start, int count)
    {
        var groups = await _reader.GetGroups(start, count);
        _logger.Info("All groups loaded");
        
        return groups;
    }

    /// <summary>
    /// Get the group corresponding to the id passed as parameter.
    /// </summary>
    /// <param name="groupId">Id of the group to search</param>
    /// <returns>Group corresponding to the id or null if it does not exist</returns>
    public async Task<Group?> GetGroupById(ulong groupId)
    {
        var group = await _reader.GetGroupById(groupId);
        
        if(group is null) _logger.Warn($"Group with id {groupId} not found");
        else _logger.Info($"Group with id {groupId} loaded");
        
        return group;
    }

    /// <summary>
    /// Get groups searching by name with pagination. 
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups filtered and paginated</returns>
    public async Task<IEnumerable<Group>> GetGroupsByName(string pattern, int start, int count)
    {
        var groups = await _reader.GetGroupsByName(pattern, start, count);
        _logger.Info($"Groups filtered with name {pattern} loaded");
        
        return groups;
    }

    /// <summary>
    /// Get groups of the player with pagination.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups of the player with pagination</returns>
    public async Task<IEnumerable<Group>> GetGroupsByPlayer(ulong playerId, int start, int count)
    {
        var groups = await _reader.GetGroupsByPlayer(playerId, start, count);
        _logger.Info($"Groups of player {playerId} loaded");
        
        return groups;
    }
    
    #endregion
    
    #region Hand

    /// <summary>
    /// Get the hand corresponding to id passed as parameter
    /// </summary>
    /// <param name="handId">Id of the hand to search</param>
    /// <returns>Hand corresponding to the id or null if it does not exist</returns>
    public async Task<Hand?> GetHandById(ulong handId)
    {
        var hand = await _reader.GetHandById(handId);
        
        if(hand is null) _logger.Warn($"Hand with id {handId} not found");
        else _logger.Info($"Hand with id {handId} loaded");

        return hand;
    }
    
    #endregion
    
    #region Game

    /// <summary>
    /// Get games with pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games paginated</returns>
    public async Task<IEnumerable<Game>> GetGames(int start, int count)
    { 
        var games = await _reader.GetGames(start, count);
        _logger.Info("All games loaded");
        
        return games;
    }

    /// <summary>
    /// Get the game corresponding to the id passed as parameter.
    /// </summary>
    /// <param name="gameId">Id of the game to search</param>
    /// <returns>Game corresponding to the id or null if it does not exist</returns>
    public async Task<Game?> GetGameById(ulong gameId)
    {
        var game = await _reader.GetGameById(gameId);
        
        if(game is null) _logger.Warn($"Game with id {gameId} not found");
        else _logger.Info($"Game with id {gameId} loaded");

        return game;
    }

    /// <summary>
    /// Get games searching by name with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    public async Task<IEnumerable<Game>> GetGamesByName(string pattern, int start, int count)
    {
        var games = await _reader.GetGamesByName(pattern, start, count);
        _logger.Info($"Games filtered with name {pattern} loaded");
        
        return games;
    }

    /// <summary>
    /// Get games searching by name with pagination.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    public async Task<IEnumerable<Game>> GetGamesByPlayer(ulong playerId, int start, int count)
    {
        var games = await _reader.GetGamesByPlayer(playerId, start, count);
        _logger.Info($"Games of player {playerId} loaded");
        
        return games;
    }

    /// <summary>
    /// Get games searching on date interval with pagination.
    /// </summary>
    /// <param name="startDate">Start date to filter</param>
    /// <param name="endDate">End date to filter</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    public async Task<IEnumerable<Game>> GetGamesByDate(DateTime startDate, DateTime? endDate, int start, int count)
    { 
        var games = await _reader.GetGamesByDate(startDate, endDate, start, count);
        _logger.Info($"Games filtered with date {startDate} - {endDate} loaded");
        
        return games;
    }
    
    #endregion
}

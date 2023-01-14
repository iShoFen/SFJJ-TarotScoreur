using System.Collections;
using Model.Games;
using Model.Players;

namespace Model.Data;

public partial interface IReader
{
    /// <summary>
    /// Get games with pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games paginated</returns>
    Task<IEnumerable<Game>> GetGames(int start, int count);

    /// <summary>
    /// Get the game corresponding to the id passed as parameter.
    /// </summary>
    /// <param name="gameId">Id of the game to search</param>
    /// <returns>Game corresponding to the id or null if it does not exist</returns>
    Task<Game?> GetGameById(ulong gameId);

    /// <summary>
    /// Get games searching by name with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    Task<IEnumerable<Game>> GetGamesByName(string pattern, int start, int count);

    /// <summary>
    /// Get games searching by name with pagination.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    Task<IEnumerable<Game>> GetGamesByPlayer(ulong playerId, int start, int count);

    /// <summary>
    /// Get games searching on date interval with pagination.
    /// </summary>
    /// <param name="startDate">Start date to filter</param>
    /// <param name="endDate">End date to filter</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of games filtered and paginated</returns>
    Task<IEnumerable<Game>> GetGamesByDate(DateTime startDate, DateTime endDate, int start, int count);
}
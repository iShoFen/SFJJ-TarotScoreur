using Model.Players;

namespace Model.Data;

public partial interface IReader
{
    /// <summary>
    /// Get players with the pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players paginated</returns>
    Task<IEnumerable<Player>> GetPlayers(int start, int count);

    /// <summary>
    /// Get the player corresponding to the id.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <returns>Player corresponding to the id or null it does not exist.</returns>
    Task<Player?> GetPlayerById(ulong playerId);

    /// <summary>
    /// Get players by searching on firstname, lastname, and nickname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    Task<IEnumerable<Player>> GetPlayersByPattern(string pattern, int start, int count);

    /// <summary>
    /// Get players by searching on nickname field with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    Task<IEnumerable<Player>> GetPlayersByNickname(string pattern, int start, int count);

    /// <summary>
    /// Get players by searching on firstname and lastname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of players to return</param>
    /// <returns>List of players filtered with the pattern and pagination</returns>
    Task<IEnumerable<Player>> GetPlayersByFirstNameAndLastName(string pattern, int start, int count);
}
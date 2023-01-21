using Model.Players;

namespace Model.Data;

public partial interface IReader
{
    /// <summary>
    /// Get groups with pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups paginated</returns>
    Task<IEnumerable<Group>> GetGroups(int start, int count);

    /// <summary>
    /// Get the group corresponding to the id passed as parameter.
    /// </summary>
    /// <param name="groupId">Id of the group to search</param>
    /// <returns>Group corresponding to the id or null if it does not exist</returns>
    Task<Group?> GetGroupById(ulong groupId);

    /// <summary>
    /// Get groups searching by name with pagination. 
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups filtered and paginated</returns>
    Task<IEnumerable<Group>> GetGroupsByName(string pattern, int start, int count);

    /// <summary>
    /// Get groups of the player with pagination.
    /// </summary>
    /// <param name="playerId">Id of the player to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of groups of the player with pagination</returns>
    Task<IEnumerable<Group>> GetGroupsByPlayer(ulong playerId, int start, int count);
}
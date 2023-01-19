using Model.Players;

namespace Model.Data;

public partial interface IWriter
{
    /// <summary>
    /// Insert a new group.
    /// </summary>
    /// <param name="group">Group to insert</param>
    /// <returns>The inserted group or null if the player has an id not equals to 0</returns>
    Task<Group?> InsertGroup(Group group);

    /// <summary>
    /// Update a group.
    /// </summary>
    /// <param name="group">Group to update</param>
    /// <returns>Group updated or null if the group does not exist</returns>
    Task<Group?> UpdateGroup(Group group);

    /// <summary>
    /// Delete a group with id.
    /// </summary>
    /// <param name="groupId">Id of the group to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteGroup(ulong groupId);

    /// <summary>
    /// Delete a player with object.
    /// </summary>
    /// <param name="group">Group to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteGroup(Group group);
}
using Model.Players;

namespace Model.Data;

public partial interface IWriter
{
    /// <summary>
    /// Insert a new user.
    /// </summary>
    /// <param name="user">user to insert</param>
    /// <returns>The user inserted or null if the user has an id not equals to 0</returns>
    Task<User?> InsertUser(User user);

    /// <summary>
    /// Update a user.
    /// </summary>
    /// <param name="user">user to update</param>
    /// <returns>user updated or null if the user does not exist</returns>
    Task<User?> UpdateUser(User user);

    /// <summary>
    /// Delete a user with id.
    /// </summary>
    /// <param name="userId">Id of the user to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteUser(ulong userId);

    /// <summary>
    /// Delete a user with object.
    /// </summary>
    /// <param name="user">user to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteUser(User user);
}
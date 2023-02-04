using Model.Players;

namespace Model.Data;

public partial interface IReader
{
        /// <summary>
    /// Get Users with the pagination.
    /// </summary>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of Users to return</param>
    /// <returns>List of Users paginated</returns>
    Task<IEnumerable<User>> GetUsers(int start, int count);

    /// <summary>
    /// Get the user corresponding to the id.
    /// </summary>
    /// <param name="userId">Id of the User to search</param>
    /// <returns>User corresponding to the id or null it does not exist.</returns>
    Task<User?> GetUserById(ulong userId);

    /// <summary>
    /// Get users by searching on firstname, lastname, and nickname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of Users to return</param>
    /// <returns>List of Users filtered with the pattern and pagination</returns>
    Task<IEnumerable<User>> GetUsersByPattern(string pattern, int start, int count);

    /// <summary>
    /// Get users by searching on nickname field with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of Users to return</param>
    /// <returns>List of Users filtered with the pattern and pagination</returns>
    Task<IEnumerable<User>> GetUsersByNickname(string pattern, int start, int count);

    /// <summary>
    /// Get users by searching on firstname and lastname fields with pagination.
    /// </summary>
    /// <param name="pattern">Pattern to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of Users to return</param>
    /// <returns>List of Users filtered with the pattern and pagination</returns>
    Task<IEnumerable<User>> GetUsersByFirstNameAndLastName(string pattern, int start, int count);
}

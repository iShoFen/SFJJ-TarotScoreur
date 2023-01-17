using Model.Games;

namespace Model.Data;

public partial interface IReader : IDisposable
{
    /// <summary>
    /// Get the hand corresponding to id passed as parameter
    /// </summary>
    /// <param name="handId">Id of the hand to search</param>
    /// <returns>Hand corresponding to the id or null if it does not exist</returns>
    Task<Hand?> GetHandById(ulong handId);
}
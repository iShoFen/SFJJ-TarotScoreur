using Model.Games;
using Model.Players;

namespace Model.Data;

public partial interface IReader
{
    /*========== Hands ==========*/

    /// <summary>
    /// Get hands of the game corresponding to the id passed as parameter.
    /// </summary>
    /// <param name="gameId">Id of the game to search</param>
    /// <param name="start">Index of the page</param>
    /// <param name="count">Number of groups to return</param>
    /// <returns>List of hands in the game with pagination</returns>
    Task<IEnumerable<KeyValuePair<int, Hand>>> GetHandsByGame(ulong gameId, int start, int count);

    /*========== End Hands ==========*/
}
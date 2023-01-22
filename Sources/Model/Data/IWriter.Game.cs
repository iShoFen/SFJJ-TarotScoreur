using Model.Games;

namespace Model.Data;

public partial interface IWriter
{
    /// <summary>
    /// Insert a new game.
    /// </summary>
    /// <param name="game">Game to insert</param>
    /// <returns>The inserted game or null if the game has an id not equals to 0</returns>
    Task<Game?> InsertGame(Game game);

    /// <summary>
    /// Update a game.
    /// </summary>
    /// <param name="game">Game to update</param>
    /// <returns>Game updated or null if the player does not exist</returns>
    Task<Game?> UpdateGame(Game game);

    /// <summary>
    /// Delete a game with id.
    /// </summary>
    /// <param name="gameId">Id of the game to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteGame(ulong gameId);

    /// <summary>
    /// Delete a game with object.
    /// </summary>
    /// <param name="game">Game to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteGame(Game game);
}
using Model.Players;

namespace Model.Data;

public partial interface IWriter
{
    /// <summary>
    /// Insert a new player.
    /// </summary>
    /// <param name="player">Player to insert</param>
    /// <returns>The player inserted or null if the player has an id not equals to 0</returns>
    Task<Player?> InsertPlayer(Player player);

    /// <summary>
    /// Update a player.
    /// </summary>
    /// <param name="player">Player to update</param>
    /// <returns>Player updated or null if the player does not exist</returns>
    Task<Player?> UpdatePlayer(Player player);

    /// <summary>
    /// Delete a player with id.
    /// </summary>
    /// <param name="playerId">Id of the player to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeletePlayer(ulong playerId);

    /// <summary>
    /// Delete a player with object.
    /// </summary>
    /// <param name="player">Player to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeletePlayer(Player player);
}
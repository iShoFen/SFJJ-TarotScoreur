using Model.Games;

namespace Model.Data;

public partial interface IWriter
{
    /// <summary>
    /// Insert a new hand.
    /// </summary>
    /// <param name="gameId">The id of the game</param>
    /// <param name="hand">The hand to insert</param>
    /// <returns>The inserted hand or null of the hand has an id not equals to 0</returns>
    Task<Hand?> InsertHand(ulong gameId, Hand hand);

    /// <summary>
    /// Update a hand.
    /// </summary>
    /// <param name="hand">Hand to update</param>
    /// <returns>Hand updated or null if it does not exist</returns>
    Task<Hand?> UpdateHand(Hand hand);

    /// <summary>
    /// Delete a hand with id.
    /// </summary>
    /// <param name="handId">Id of the hand to delete</param>
    /// <returns>True if deleted otherwise false</returns>
    Task<bool> DeleteHand(ulong handId);

    /// <summary>
    /// Delete a hand with object.
    /// </summary>
    /// <param name="hand">Hand to delete</param>
    /// <returns>True id deleted otherwise false</returns>
    Task<bool> DeleteHand(Hand hand);
}
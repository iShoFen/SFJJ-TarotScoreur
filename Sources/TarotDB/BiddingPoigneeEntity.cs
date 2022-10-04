using TarotDB.enums;

namespace TarotDB;

/// <summary>
/// A join entity for dictionary entries and their translations. (Represent a Bidding in HandEntity)
/// <see cref="Hand"/>
/// </summary>
internal class BiddingPoigneeEntity
{
    /// <summary>
    /// The type of the bidding
    /// </summary>
    public Bidding Bidding { get; set; }
    
    /// <summary>
    /// The type of the poignee
    /// </summary>
    public Poignee Poignee { get; set; }
    
    /// <summary>
    /// The unique identifier of the hand
    /// </summary>
    public ulong HandId { get; set; }
    
    /// <summary>
    /// The hand
    /// </summary>
    public HandEntity Hand { get; set; } = null!;
    
    /// <summary>
    /// The unique identifier of the player
    /// </summary>
    public ulong PlayerId { get; set; }
    
    /// <summary>
    /// The player
    /// </summary>
    public PlayerEntity Player { get; set; } = null!;
}
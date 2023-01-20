using TarotDB.Enums;

namespace TarotDB;

/// <summary>
/// A join entity for dictionary entries and their translations. (Represent a BiddingDB in HandEntity)
/// <see cref="Hand"/>
/// </summary>
internal class BiddingPoigneeEntity
{
    /// <summary>
    /// The type of the bidding
    /// </summary>
    public BiddingsDb Biddings { get; set; }

    /// <summary>
    /// The type of the poignee
    /// </summary>
    public PoigneeDb Poignee { get; set; }

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

    public static EqualityComparer<BiddingPoigneeEntity> Comparer { get; } = new BiddingPoigneeEntityComparer();
}

internal class BiddingPoigneeEntityComparer : EqualityComparer<BiddingPoigneeEntity>
{
    public override bool Equals(BiddingPoigneeEntity? x, BiddingPoigneeEntity? y)
    {
        if (x == null || y == null) return false;
        if (x.Player.Id == 0 || y.Player.Id == 0 || x.Hand.Id == 0 || y.Hand.Id == 0) return false;

        return x.Player.Id == y.Player.Id && x.Hand.Id == y.Hand.Id;
    }

    public override int GetHashCode(BiddingPoigneeEntity obj) => obj.Hand.GetHashCode();
}
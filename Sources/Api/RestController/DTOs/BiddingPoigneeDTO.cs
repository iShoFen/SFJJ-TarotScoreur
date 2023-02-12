using RestController.DTOs.Enums;

namespace RestController.DTOs;

public class BiddingPoigneeDTO : IEquatable<BiddingPoigneeDTO>
{
    // <summary>
    /// The type of the Bidding
    /// </summary>
    public BiddingsDTO Biddings { get; set; }
    
    /// <summary>
    /// The type of the Poignee
    /// </summary>
    public PoigneeDTO Poignee { get; set; }
    
    /// <summary>
    /// The unique identifier of the User
    /// </summary>
    public ulong UserId { get; set; }

    public bool Equals(BiddingPoigneeDTO? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Biddings.Equals(other.Biddings) && Poignee.Equals(other.Poignee) && UserId == other.UserId;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BiddingPoigneeDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Biddings, (int)Poignee, UserId);
    }
}
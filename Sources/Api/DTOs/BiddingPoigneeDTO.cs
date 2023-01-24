using DTOs.Enums;

namespace DTOs;

public class BiddingPoigneeDto
{
    // <summary>
    /// The type of the Bidding
    /// </summary>
    public BiddingsDto Biddings { get; set; }
    
    /// <summary>
    /// The type of the Poignee
    /// </summary>
    public PoigneeDto Poignee { get; set; }
    
    /// <summary>
    /// The unique identifier of the Hand
    /// </summary>
    public ulong HandId { get; set; }
    
    /// <summary>
    /// The Hand
    /// </summary>
    public HandDto Hand { get; set; } = null!;
    
    /// <summary>
    /// The unique identifier of the User
    /// </summary>
    public ulong UserId { get; set; }
    
    /// <summary>
    /// The User
    /// </summary>
    public UserDTO User { get; set; } = null!;
}
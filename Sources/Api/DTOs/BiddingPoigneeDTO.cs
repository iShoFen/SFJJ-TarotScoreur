using DTOs.Enums;

namespace DTOs;

public class BiddingPoigneeDTO
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
    /// The unique identifier of the Hand
    /// </summary>
    public ulong HandId { get; set; }
    
    /// <summary>
    /// The Hand
    /// </summary>
    public HandDTO Hand { get; set; } = null!;
    
    /// <summary>
    /// The unique identifier of the User
    /// </summary>
    public ulong UserId { get; set; }
    
    /// <summary>
    /// The User
    /// </summary>
    public UserDTO User { get; set; } = null!;
}
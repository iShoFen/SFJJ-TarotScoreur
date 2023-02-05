using RestController.DTOs.Enums;

namespace RestController.DTOs;

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
    /// The unique identifier of the User
    /// </summary>
    public ulong UserId { get; set; }
   
}
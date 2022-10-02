using System.ComponentModel.DataAnnotations;
using TarotDB.enums;

namespace TarotDB;

internal class BiddingPoigneeEntity
{
    public Bidding Bidding { get; set; }
    public Poignee Poignee { get; set; }
    public HandEntity Hand { get; set; } = null!;
    public PlayerEntity Player { get; set; } = null!;
}
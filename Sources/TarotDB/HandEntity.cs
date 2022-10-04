using TarotDB.enums;

namespace TarotDB;

/// <summary>
/// Represents a Hand in the Database
/// </summary>
internal class HandEntity
{
    /// <summary>
    /// The unique identifier for the Hand
    /// </summary>
    public ulong Id { get; set; }
    
    /// <summary>
    /// The number of the Hand
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// The of the rules applied to this Hand
    /// </summary>
    public string Rules { get; set; } = null!;
    
    /// <summary>
    /// The date of the Hand
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// The score of the taker
    /// </summary>
    public int TakerScore { get; set; }
    
    /// <summary>
    /// Indicates if the taker as the twenty one oudler
    /// </summary>
    public bool? TwentyOne { get; set; }
    
    /// <summary>
    /// Indicates if the taker as the excuse oudler
    /// </summary>
    public bool? Excuse { get; set; }
    
    /// <summary>
    /// Indicates the state of the Petit related to the taker
    /// </summary>
    public PetitResult Petit { get; set; }
    
    /// <summary>
    /// Indicates the state of the Chelem related to the taker
    /// </summary>
    public Chelem Chelem { get; set; }
    
    /// <summary>
    /// Players bidding details
    /// </summary>
    public ICollection<BiddingPoigneeEntity> Biddings { get; set; } = new HashSet<BiddingPoigneeEntity>();
    
    /// <summary>
    /// The game to which the Hand belongs
    /// </summary>
    public GameEntity Game { get; set; } = null!;
}

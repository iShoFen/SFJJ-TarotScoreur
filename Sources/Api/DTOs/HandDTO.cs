using DTOs.Enums;

namespace DTOs;

/**
 * DTO for the Hand table
 */
public class HandDTO
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
    /// The name of the rules applied to this Hand
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
    public PetitResultsDTO Petit { get; set; }
    
    /// <summary>
    /// Indicates the state of the ChelemDB related to the taker
    /// </summary>
    public ChelemDTO Chelem { get; set; }
    
    /// <summary>
    /// Users bidding details
    /// </summary>
    public ICollection<BiddingPoigneeDTO> Biddings { get; set; } = new HashSet<BiddingPoigneeDTO>();
    
    /// <summary>
    /// The game to which the Hand belongs
    /// </summary>
    public GameDTO Game { get; set; } = null!;
}
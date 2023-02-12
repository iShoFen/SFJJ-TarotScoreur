using RestController.DTOs.Enums;

namespace RestController.DTOs;

/**
 * DTO for the Hand table
 */
public class HandDTODetail : IEquatable<HandDTODetail>
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
    
    public ICollection<BiddingPoigneeDTO> Biddings { get; set; } = new HashSet<BiddingPoigneeDTO>();

    /// <summary>
    /// The game to which the Hand belongs
    /// </summary> 
    public ulong GameId { get; set; }

    public bool Equals(HandDTODetail? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Number == other.Number && Rules == other.Rules && Date.Equals(other.Date) && TakerScore == other.TakerScore && TwentyOne == other.TwentyOne && Excuse == other.Excuse && Petit.Equals(other.Petit) && Chelem.Equals(other.Chelem) && Biddings.Equals(other.Biddings) && GameId == other.GameId;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((HandDTODetail)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(Number);
        hashCode.Add(Rules);
        hashCode.Add(Date);
        hashCode.Add(TakerScore);
        hashCode.Add(TwentyOne);
        hashCode.Add(Excuse);
        hashCode.Add((int)Petit);
        hashCode.Add((int)Chelem);
        hashCode.Add(Biddings);
        hashCode.Add(GameId);
        return hashCode.ToHashCode();
    }
}
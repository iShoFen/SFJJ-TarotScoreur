using System.Collections.ObjectModel;
using Model.enums;

namespace Model.Gaming;

/// <summary>
/// Stores the information about a Hand, the players biddings and rules
/// </summary>
public partial class Hand
{
    /// <summary>
    /// The unique identifier for the hand
    /// </summary>
    public int Id { get; }
        
    /// <summary>
    /// The number of the hand
    /// </summary>
    public int HandNumber { get; }
        
    /// <summary>
    /// The date of the hand
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// The score of the taker
    /// </summary>
    public int TakerScore { get; }
        
    /// <summary>
    /// Indicates if the taker as the twenty one oudler
    /// </summary>
    public bool? TwentyOne { get; }
        
    /// <summary>
    /// Indicates if the taker as the excuse oudler
    /// </summary>
    public bool? Excuse { get; }
        
    /// <summary>
    /// Indicates the state of the Petit related to the taker
    /// </summary>
    public PetitResult Petit { get; }
        
    /// <summary>
    /// Indicates the state of the Chelem related to the taker
    /// </summary>
    public Chelem Chelem { get; }
        
    /// <summary>
    /// Players bidding details
    /// </summary>
    public ReadOnlyDictionary<Player, (Bidding,Poignee)> Biddings { get; }
    private readonly Dictionary<Player, (Bidding, Poignee)> _biddings;

    private readonly IRules _rules;
        
    public IReadOnlyDictionary<Player, int> Scores => _rules.GetHandScore(this);

    /// <summary>
    /// Full constructor used to create a new game from existing data
    /// </summary>
    /// <param name="handNumber"> The number of the hand </param>
    /// <param name="date"> The date of the hand </param>
    /// <param name="takerScore"> The score of the taker </param>
    /// <param name="twentyOne"> Indicates if the taker as the twenty one oudler </param>
    /// <param name="excuse"> Indicates if the taker as the excuse oudler </param>
    /// <param name="biddings"> Players bidding details </param>
    public Hand(int handNumber, DateTime date, int takerScore, bool? twentyOne, bool? excuse, IEnumerable<KeyValuePair<Player, (Bidding, Poignee)>> biddings)
    {
        HandNumber = handNumber;
        Date = date;
        TakerScore = takerScore;
        TwentyOne = twentyOne;
        Excuse = excuse;
        _biddings = biddings.ToDictionary(x => x.Key, x => x.Value);
        Biddings = new ReadOnlyDictionary<Player, (Bidding, Poignee)>(_biddings);
    }
        
    /// <summary>
    /// Constructor used to create a new hand
    /// </summary>
    /// <param name="number"> The number of the hand </param>
    /// <param name="date"> The date of the hand </param>
    public Hand(int number, DateTime date) : this(number, date, 0, null, null, new Dictionary<Player, (Bidding, Poignee)>()) { }
        
    /// <summary>
    /// Add a bidding to the hand
    /// </summary>
    /// <param name="player"> The player who bid </param>
    /// <param name="bidding"> The bidding </param>
    /// <param name="poignee"> The poignee </param>
    public void AddBidding(Player player, Bidding bidding, Poignee poignee)
    {
        if (_biddings.ContainsKey(player))
        {
            _biddings[player] = (bidding, poignee);
        }
        else
        {
            _biddings.Add(player, (bidding, poignee));                
        }
    }
        
    /// <summary>
    /// Check if the hand is valid (all information are filled and correct) 
    /// </summary>
    /// <returns> True if the hand is valid, false otherwise </returns>
    public bool IsValid()
    {
        throw new NotImplementedException();
    }

    public bool Equals(Hand? other)
    {
        if (other is null) return false;
        if (other.Id == Id) return true;
        return other.Id == 0 && Hand.FullComparer.Equals(this, other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as Hand);
    }

    public override int GetHashCode() => Id.GetHashCode();
    public override string ToString() => $"({Id}) {HandNumber} ({Date:dd/MM/yyyy})";
}
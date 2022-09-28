using System.Collections.ObjectModel;
using Model.enums;

namespace Model.games;

/// <summary>
/// Stores the information about a Hand, the players biddings and rules
/// </summary>
public partial class Hand : IEquatable<Hand>
{
    /// <summary>
    /// The unique identifier for the hand
    /// </summary>
    public ulong Id { get; }
        
    /// <summary>
    /// The number of the hand
    /// </summary>
    public int HandNumber { get; }

    /// <summary>
    /// The Rules of the game applied to this hand
    /// </summary>
    public IRules Rules
    {
        get => _rules;
        init => _rules = value ?? throw new ArgumentNullException(nameof(value), "Rules cannot be null");
    }
    private readonly IRules _rules = null!;

    /// <summary>
    /// The date of the hand
    /// </summary>
    public DateTime Date
    {
        get => _date;
        private init => _date = value == default ? throw new ArgumentException("Date cannot be default", nameof(value)) : value;
    }
    private readonly DateTime _date;

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
    private readonly Dictionary<Player, (Bidding, Poignee)> _biddings = new();

    public IReadOnlyDictionary<Player, int> Scores => _rules.GetHandScore(this);

    /// <summary>
    /// Full constructor used to create a new game from existing data
    /// </summary>
    /// <param name="id">The unique identifier for the hand</param>
    /// <param name="handNumber"> The number of the hand </param>
    /// <param name="rules"> The Rules of the game applied to this hand </param>
    /// <param name="date"> The date of the hand </param>
    /// <param name="takerScore"> The score of the taker </param>
    /// <param name="twentyOne"> Indicates if the taker as the twenty one oudler </param>
    /// <param name="excuse"> Indicates if the taker as the excuse oudler </param>
    /// <param name="petit"> Indicates the state of the Petit related to the taker </param>
    /// <param name="chelem"> Indicates the state of the Chelem related to the taker </param>
    /// <param name="biddings"> Players bidding details </param>
    public Hand(ulong id, int handNumber, IRules rules, DateTime date, int takerScore, bool? twentyOne, bool? excuse, 
        PetitResult petit, Chelem chelem, params KeyValuePair<Player,(Bidding, Poignee)>[] biddings)
    {
        Id = id;
        HandNumber = handNumber;
        Rules = rules;
        Date = date;
        TakerScore = takerScore;
        TwentyOne = twentyOne;
        Excuse = excuse;
        Petit = petit;
        Chelem = chelem;
        AddBiddings(biddings);
        Biddings = new ReadOnlyDictionary<Player, (Bidding, Poignee)>(_biddings);
    }
        
    /// <summary>
    /// Constructor used to create a new hand
    /// </summary>
    /// <param name="number"> The number of the hand </param>
    /// <param name="rules"> The Rules of the game applied to this hand </param>
    /// <param name="date"> The date of the hand </param>
    public Hand(int number, IRules rules, DateTime date, int takerScore, bool? twentyOne, bool? excuse, 
        PetitResult petit, Chelem chelem, params KeyValuePair<Player,(Bidding, Poignee)>[] biddings) : 
        this(0UL, number, rules, date, takerScore, twentyOne, excuse, petit, chelem, biddings) {}
        
    /// <summary>
    /// Add a bidding to the hand
    /// </summary>
    /// <param name="player"> The player who bid </param>
    /// <param name="bidding"> The bidding </param>
    /// <param name="poignee"> The poignee </param>
    /// <returns> true if the bidding was added, false if the player already bid </returns>
    public bool AddBidding(Player player, Bidding bidding, Poignee poignee) => _biddings.TryAdd(player, (bidding, poignee));

    /// <summary>
    /// Add multiple biddings to the hand
    /// </summary>
    /// <param name="biddings"> The biddings to add </param>
    /// <returns> true if all the biddings were added, false if at least one player already bid </returns>
    public bool AddBiddings(params KeyValuePair<Player, (Bidding, Poignee)>[] biddings) => 
        biddings.All(b => !_biddings.ContainsKey(b.Key))  
        && biddings.All(b => AddBidding(b.Key, b.Value.Item1, b.Value.Item2));

    /// <summary>
    /// Check if the hand is valid (all information are filled and correct) 
    /// </summary>
    /// <returns> True if the hand is valid, false otherwise </returns>
    public bool IsValid(out Validity validity)
    {
        validity = Rules.IsHandValid(this, out var isValid);
        return isValid;
    }

    /// <summary>
    /// Check if this Hand is equal to another Hand
    /// </summary>
    /// <param name="other"> The other Hand to compare to </param>
    /// <returns> True if the two Hands are equal, false otherwise </returns>
    public bool Equals(Hand? other)
    {
        if (Id == 0 || other!.Id == 0) return FullComparer.Equals(this, other);
        return Id == other.Id;
    }

    /// <summary>
    /// Check if this Hand is equal to another object
    /// </summary>
    /// <param name="obj"> The other object to compare to </param>
    /// <returns> True if the two objects are equal, false otherwise </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as Hand);
    }

    /// <summary>
    /// Get the hash code of the Hand
    /// </summary>
    /// <returns> The hash code of the Hand </returns>
    public override int GetHashCode() => Id == 0 ? FullComparer.GetHashCode(this) : Id.GetHashCode() % 31;

    /// <summary>
    /// Get a string representation of the Hand
    /// </summary>
    /// <returns> A string representation of the Hand </returns>
    public override string ToString() => $"({Id}) {HandNumber} ({Date:dd/MM/yyyy})";
}
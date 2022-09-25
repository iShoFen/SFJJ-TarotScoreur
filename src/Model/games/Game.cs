using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Model.games;

/// <summary>
/// Stores the information about a Game, including the players, all the hands played and the rules
/// </summary>
public partial class Game : IEquatable<Game>
{
    /// <summary>
    /// The unique identifier for the game.
    /// </summary>
    public ulong Id { get; }

    /// <summary>
    /// The name of the game
    /// </summary>
    public string Name
    {
        get => _name;
        private init => _name = string.IsNullOrWhiteSpace(value) 
            ? throw new ArgumentException("Game name cannot be null or empty", nameof(value))
            : value;
    }
    private readonly string _name;

    public IRules Rules
    {
        get => _rules;
        private init => _rules = value ?? throw new ArgumentNullException(nameof(value), "Game rules cannot be null");
    }
    private readonly IRules _rules;


    /// <summary>
    /// The start date of the game
    /// </summary>
    public DateTime StartDate
    {
        get => _startDate;
        private init => _startDate = value == default
            ? throw new ArgumentException("Game start date cannot be the default value", nameof(value))
            : value;
    }
    private readonly DateTime _startDate;
        
    /// <summary>
    /// The end date of the game
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public DateTime? EndDate { 
        get => _endDate;
        private init => _endDate = value < StartDate
            ? throw new ArgumentException("Game end date cannot be before the start date", nameof(value))
            : value;
    }
    private readonly  DateTime? _endDate;
    
    /// <summary>
    /// The list of Hands played in the game
    /// </summary>
    public ReadOnlyDictionary<int, Hand> Hands { get; }
    private readonly SortedList<int, Hand> _hands = new();
        
    /// <summary>
    /// The list of players in the game
    /// </summary>
    public ReadOnlyCollection<Player> Players { get; }
    private readonly List<Player> _players = new();

    /// <summary>
    /// Full constructor used to create a new game from existing data
    /// </summary>
    /// <param name="id"> The id of the game in the database </param>
    /// <param name="name"> The name of the game </param>
    /// <param name="rules"> The rules of the game </param>
    /// <param name="startDate"> The start date of the game </param>
    /// <param name="endDate"> The end date of the game </param>
    public Game(ulong id, string name, IRules rules, DateTime startDate, DateTime? endDate)
    {
        Id = id;
        Name = name;
        Rules = rules;
        StartDate = startDate;
        EndDate = endDate;
        Players = new ReadOnlyCollection<Player>(_players);
        Hands = new ReadOnlyDictionary<int, Hand>(_hands);
    }
    
    /// <summary>
    /// Constructor used to create a new game
    /// </summary>
    /// <param name="name"> The name of the game </param>
    /// <param name="rules"> The rules of the game </param>
    /// <param name="startDate"> The start date of the game </param>
    public Game(string name, IRules rules, DateTime startDate) : this(0L, name, rules, startDate, null) { }

    /// <summary>
    /// Add a player to the game
    /// </summary>
    /// <param name="player"> The player to add </param>
    /// <returns> true if the player was added, false if the player was already in the game </returns>
    public bool AddPlayer(Player player)
    {
        if (_players.Contains(player)) return false;
        _players.Add(player);
        
        return true;
    }

    /// <summary>
    /// Add multiple players to the game
    /// </summary>
    /// <param name="players"> The players to add </param>
    /// <returns> true if all players were added, false if at least one player was already in the game </returns>
    public bool AddPlayers(params Player[] players)
    {
        var canAllBeAdded = players.Any(player => _players.Contains(player));
        return !canAllBeAdded && players.All(AddPlayer);
    }
    
    /// <summary>
    /// Add a hand to the game
    /// </summary>
    /// <param name="hand"> The hand to add </param>
    /// <returns> true if the hand was added, false if the hand was already in the game </returns>
    public bool AddHand(Hand hand) => _hands.TryAdd(hand.HandNumber, hand);

    /// <summary>
    /// Add multiple hands to the game
    /// </summary>
    /// <param name="hands"> The hands to add </param>
    /// <returns> true if all hands were added, false if at least one hand was already in the game </returns>
    public bool AddHands(params Hand[] hands) => hands.All(hand => !_hands.ContainsKey(hand.HandNumber)) && hands.All(AddHand);
    

    /// <summary>
    /// Check if the game is valid
    /// </summary>
    /// <returns> true if the game is valid, false otherwise </returns>
    public Validity IsValid() => Rules.IsGameValid(this);
    
    /// <summary>
    /// Get the score of all the hands played in the game
    /// </summary>
    /// <returns> The score of all the hands played in the game </returns>
    public IEnumerable<IReadOnlyDictionary<Player, int>> GetScores() => Hands.Select(hand => Rules.GetHandScore(hand.Value)).ToList();
    
    /// <summary>
    /// Checks if this Game is equal to another Game
    /// </summary>
    /// <param name="other"> The other Game to compare to </param>
    /// <returns> True if the two games are equal, false otherwise </returns>
    public bool Equals(Game? other)
    {
        if (other is null) return false;
        if (Id == 0 || other.Id == 0) return FullComparer.Equals(this, other);
        return Id == other.Id;
    }

    /// <summary>
    /// Check if this Game is equal to another object
    /// </summary>
    /// <param name="obj"> The object to compare to </param>
    /// <returns> True if the object is equal to this Game, false otherwise </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as Game);
    }

    /// <summary>
    /// Get the hash code of the Game
    /// </summary>
    /// <returns> The hash code of the Game </returns>
    public override int GetHashCode() => Id == 0 ? FullComparer.GetHashCode(this) : Id.GetHashCode() % 31;
    
    /// <summary>
    /// Get a string representation of the game
    /// </summary>
    /// <returns> A string representation of the game </returns>
    public override string ToString() => $"({Id}) {Name} {StartDate:dd/MM/yyyy} {EndDate:dd/MM/yyyy}";
}
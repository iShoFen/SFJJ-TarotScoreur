using System.Collections.ObjectModel;

namespace Model.games;

/// <summary>
/// Stores the information about a Game, including the players, all the hands played and the rules
/// </summary>
public partial class Game : IEquatable<Game>
{
    /// <summary>
    /// The unique identifier for the game.
    /// </summary>
    public long Id { get; }
        
    /// <summary>
    /// The name of the game
    /// </summary>
    public string Name { get; }
        
    /// <summary>
    /// The start date of the game
    /// </summary>
    public DateTime StartDate { get; }
        
    /// <summary>
    /// The end date of the game
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public DateTime? EndDate { 
        get => _endDate;
        init
        {
            if (value < StartDate) throw new ArgumentException("End date cannot be before start date");
            _endDate = value ?? DateTime.Now;
        }
    }
    private readonly  DateTime? _endDate;

    public IRules Rules { get; }
        
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
    /// <param name="startDate"> The start date of the game </param>
    /// <param name="endDate"> The end date of the game </param>
    public Game(long id, string name, DateTime startDate, DateTime? endDate)
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Players = new ReadOnlyCollection<Player>(_players);
        Hands = new ReadOnlyDictionary<int, Hand>(_hands);
    }
    
    /// <summary>
    /// Constructor used to create a new game
    /// </summary>
    /// <param name="name"> The name of the game </param>
    /// <param name="startDate"> The start date of the game </param>
    public Game(string name, DateTime startDate) : this(0, name, startDate, null) { }

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
    public bool AddPlayers(params Player[] players) => players.All(AddPlayer);
    
    /// <summary>
    /// Add a hand to the game
    /// </summary>
    /// <param name="hand"> The hand to add </param>
    /// <returns> true if the hand was added, false if the hand was already in the game </returns>
    public bool AddHand(Hand hand) => !_hands.ContainsKey(hand.HandNumber) && _hands.TryAdd(hand.HandNumber, hand);
    
    /// <summary>
    /// Add multiple hands to the game
    /// </summary>
    /// <param name="hands"> The hands to add </param>
    /// <returns> true if all hands were added, false if at least one hand was already in the game </returns>
    public bool AddHands(params Hand[] hands) =>  hands.All(AddHand);
    
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
        if (other.Id == Id) return true;
        return (Id == 0 || other.Id == 0) && FullComparer.Equals(this, other);
    }

    /// <summary>
    /// Checks if this Game is equal to another object
    /// </summary>
    /// <param name="obj"> The object to compare to </param>
    /// <returns> True if the object is equal to this Game, false otherwise </returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as Game);
    }

    public override int GetHashCode() => Id == 0 ? FullComparer.GetHashCode(this) : Id.GetHashCode();
    
    /// <summary>
    /// Get a string representation of the game
    /// </summary>
    /// <returns> A string representation of the game </returns>
    public override string ToString() => $"({Id}) {Name} {StartDate} {EndDate}";
}
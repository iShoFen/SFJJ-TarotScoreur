using System.Collections.ObjectModel;

namespace Model.Gaming
{
    /// <summary>
    /// Stores the information about a Game, including the players, all the hands played and the rules
    /// </summary>
    public partial class Game
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
        public ReadOnlyCollection<Hand> Hands { get; }
        private readonly SortedSet<Hand> _hands = new();
        
        /// <summary>
        /// The list of players in the game
        /// </summary>
        public ReadOnlyCollection<Player> Players { get; }
        private readonly HashSet<Player> _players = new();
        
        /// <summary>
        /// Full constructor used to create a new game from existing data
        /// </summary>
        /// <param name="id"> The id of the game in the database </param>
        /// <param name="name"> The name of the game </param>
        /// <param name="startDate"> The start date of the game </param>
        /// <param name="endDate"> The end date of the game </param>
        /// <param name="players"> The list of players in the game </param>
        /// <param name="hands"> The list of hands played in the game </param>
        public Game(long id, string name, DateTime startDate, DateTime? endDate, IEnumerable<Player> players, IEnumerable<Hand> hands)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            _players.UnionWith(players);
            Players = new ReadOnlyCollection<Player>(_players.ToList());
            _hands.UnionWith(hands);
            Hands = new ReadOnlyCollection<Hand>(_hands.ToList());
        }
        
        public IEnumerable<IReadOnlyDictionary<Player, int>> GetScores() => Hands.Select(hand => Rules.GetHandScore(hand)).ToList();


        public bool Equals(Game? other)
        {
            if (other is null) return false;
            if (other.Id == Id) return true;
            return other.Id == 0 && Game.FullComparer.Equals(this, other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as Game);
        }

        public override int GetHashCode() => Id.GetHashCode();
        public override string ToString() => $"({Id}) {Name} {StartDate} {EndDate}";
    }
}

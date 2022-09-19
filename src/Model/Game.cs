using System.Collections.ObjectModel;

namespace Model
{
    public partial class Game
    {
        /// <summary>
        /// The id of the game in the database
        /// </summary>
        public long Id { get; }
        
        /// <summary>
        /// The name of the game
        /// </summary>
        public string Name { get; internal set; }
        
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
            internal set
            {
                if (value < StartDate) throw new ArgumentException("End date cannot be before start date");
                if (_endDate != null) _endDate = value;
            }
        }
        private DateTime? _endDate;

        // TODO: Add IRules implementation
        // public IRules Rules { get; }

         // TODO: Add the the IRules implementation
        /*public IEnumerable<IReadOnlyDictionary<Player, int>> Scores;
         { get
             {
                 
             } 
         }*/
        
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
        
        /// <summary>
        /// Constructor used to create a new game
        /// </summary>
        /// <param name="name"> The name of the game </param>
        /// <param name="startDate"> The start date of the game </param>
        /// <param name="players"> The list of players in the game </param>
        public Game(string name, DateTime startDate) : this(0, name, startDate, null, new List<Player>(), new List<Hand>()) { }

        /// <summary>
        /// Adds a player to the game
        /// </summary>
        /// <param name="player"> The player to add </param>
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        
        /// <summary>
        /// Removes a player from the game
        /// </summary>
        /// <param name="player"> The player to remove </param>
        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }
        
        /// <summary>
        /// Adds a hand to the game
        /// </summary>
        /// <param name="hand"> The hand to add </param>
        public void AddHand(Hand hand)
        {
            _hands.Add(hand);
        }
        
        /// <summary>
        /// Checks if the game is valid (all information are filled and correct)
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.ObjectModel;
using Model.enums;

namespace Model
{
    public partial class Hand
    {
        public ulong Id { get; }
        /// <summary>
        /// The number of the hand
        /// </summary>
        public int HandNumber { get; }
        /// <summary>
        /// 
        /// </summary>
        private readonly IRules _rules;
        
        /// <summary>
        /// The date of the hand
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// The score of the taker
        /// </summary>
        public int TakerScore { get; internal set; }
        
        /// <summary>
        /// Indicates if the taker as the twenty one oudler
        /// </summary>
        public bool? TwentyOne { get; internal set; }
        
        /// <summary>
        /// Indicates if the taker as the excuse oudler
        /// </summary>
        public bool? Excuse { get; internal set; }
        
        /// <summary>
        /// Indicates the state of the Petit related to the taker
        /// </summary>
        public PetitResult Petit { get; internal set; }
        
        /// <summary>
        /// Indicates the state of the Chelem related to the taker
        /// </summary>
        public Chelem Chelem { get; internal set; }
        
        /// <summary>
        /// Players bidding details
        /// </summary>
        public ReadOnlyDictionary<Player, (Bidding,Poignee)> Biddings { get; }
        private readonly Dictionary<Player, (Bidding, Poignee)> _biddings = new();

        // TODO: Add the the IRules implementation
        /*public IReadOnlyDictionary<Player, int> Scores
        {
            get
            {
                
            }
        }*/
        
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
        /// <param name="biddings"> Players bidding details </param>
        public Hand(ulong id, int handNumber, IRules rules, DateTime date, int takerScore, bool? twentyOne, bool? excuse, PetitResult petit, Chelem chelem, params KeyValuePair<Player,(Bidding, Poignee)>[] biddings)
        {
            Id = id;
            HandNumber = handNumber;
            _rules = rules;
            Date = date;
            TakerScore = takerScore;
            TwentyOne = twentyOne;
            Excuse = excuse;
            Petit = petit;
            Chelem = chelem;
            _biddings = biddings.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Biddings = new ReadOnlyDictionary<Player, (Bidding, Poignee)>(_biddings);
        }
        
        /// <summary>
        /// Constructor used to create a new hand
        /// </summary>
        /// <param name="number"> The number of the hand </param>
        /// <param name="rules"> The Rules of the game applied to this hand </param>
        /// <param name="date"> The date of the hand </param>
        public Hand(int number, IRules rules, DateTime date) : this(0, number, rules, date, 0, null, null, PetitResult.Unknown, Chelem.Unknown) { }
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
            _rules.IsHandValid(this, out var valid);
            return valid;
        }

        public IReadOnlyDictionary<Player, int> getScores()
        {
            return _rules.GetHandScore(this);
        }

    }
}

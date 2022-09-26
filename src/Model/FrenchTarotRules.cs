using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.enums;

namespace Model
{
    public class FrenchTarotRules : IRules
    {
        public int MinNbPlayers { get; } = 3;

        public int MaxNbPlayers { get; }= 5;

        public int MinNbPlayersForKing { get; } = 5;

        public int MaxNbKing { get; } = 1;

        public string Name => GetType().Name;

        private readonly Dictionary<int, int> _oudlersPoints = new()
        {
            [0] = 56,
            [1] = 51,
            [2] = 41,
            [3] = 36

        };
        //private Dictionary<Bidding, int> _biddingPrice;
        private Dictionary<Bidding, int> _multiplicators = new()
        {
        
          [Bidding.Petite] = 1,
          [Bidding.Garde] = 2,
          [Bidding.GardeSansLeChien] = 4,
          [Bidding.GardeContreLeChien] = 6,
         
        };

        private readonly Dictionary<Poignee, int> _primesPoignee = new()
        {
            [Poignee.None] = 0,
            [Poignee.Simple] = 20,
            [Poignee.Double] = 30,
            [Poignee.Triple] = 40    
        };

        private readonly Dictionary<Chelem, int> _primesChelem = new()
        {
            [Chelem.Unknown] = 0,
            [Chelem.Success] = 200,
            [Chelem.AnnouncedSuccess] = 400,
            [Chelem.AnnouncedFail] = -200
        };
        private readonly int _primeAuBout = 10;

        public IReadOnlyDictionary<Player,int> GetHandScore(Hand hand)
        {
            if (IsHandValid(hand, out _) != Validity.Valid) throw new ArgumentException("Hand is not valid");
            var neededScore = GetOudlersPoints(GetNumberOfOudlers(hand));
            var takerScore = hand.TakerScore;
            
            var score = GetTruePointOfTaker(takerScore,neededScore);
            score += GetPrimeAuBout(hand.Petit);
            score *= GetMultiplicator(hand.Biddings.Select(bidding => bidding.Value.Item1).ToList());
            if (score < 0) score -= GetPrimePoignee((hand.Biddings.Select(bidding => bidding.Value.Item2).ToList()));
            else score += GetPrimePoignee((hand.Biddings.Select(bidding => bidding.Value.Item2).ToList()));
            score += GetPrimeChelem(hand.Chelem);
            return GetAllPlayersScore(hand, score);
        }

        private IReadOnlyDictionary<Player, int> GetAllPlayersScore(Hand hand, int takerScore)
        {
            var scores = new Dictionary<Player, int>();
            foreach (var player in hand.Biddings)
            {
                if ((player.Value.Item1 & Bidding.Prise) == Bidding.Prise)
                {
                    scores.Add(player.Key, hand.Biddings.Count == 5? takerScore * 2 : takerScore * hand.Biddings.Count-1);
                }
                else if (player.Value.Item1 == Bidding.King)
                {
                    scores.Add(player.Key, takerScore);
                }
                else scores.Add(player.Key, -takerScore);
            }

            return scores;
        }

        private int GetPrimeAuBout(PetitResult petitResult)
        {
            if(petitResult == PetitResult.AuBoutOwned) return _primeAuBout;
            else if(petitResult == PetitResult.LostAuBout) return -_primeAuBout;
            else return 0;
        }
        
        /// <summary>
        /// Return the number of oudlers in the hand
        /// <param name="hand">Hand which is use</param>
        /// </summary>
        /// <returns>Number of oudlers</returns>
        private int GetNumberOfOudlers(Hand hand)
        {
            var nbOudlers = 0;
            if(hand.TwentyOne == true) ++nbOudlers;
            if(hand.Excuse == true) ++nbOudlers;
            if((hand.Petit & PetitResult.Owned) == PetitResult.Owned) ++nbOudlers;
            return nbOudlers;
        }
        /// <summary>
        /// Return the number of points needed to win the hand
        /// </summary>
        /// <param name="nbOudlers">Number of oudlers</param>
        /// <returns>Needed point to win</returns>
        private int GetOudlersPoints(int nbOudlers)
        {
            return _oudlersPoints[nbOudlers];
        }

        private int GetTruePointOfTaker(int takerScore, int neededScore)
        {
            var score = 0;
            if (takerScore >= neededScore) score = 25 + (takerScore - neededScore);
            else score = -25 - (neededScore - takerScore);
            return score;
        }
        /// <summary>
        /// Return the multiplicator of the taker bidding
        /// </summary>
        /// <param name="biddings"> List of biddings in the hand</param>
        /// <returns></returns>
        private int GetMultiplicator(IEnumerable<Bidding> biddings)
        {
            var multiplicator = 0;
            foreach (var bidding in biddings.Where(bidding => (bidding & Bidding.Prise) == Bidding.Prise))
            {
                multiplicator = _multiplicators[bidding];
            }

            return multiplicator;
        }
        
        private int GetPrimePoignee(IEnumerable<Poignee> poignees) => poignees.Sum(poignee => _primesPoignee[poignee]);

        private int GetPrimeChelem(Chelem chelem) => _primesChelem[chelem];

        public Validity IsGameValid(Game game)
        {
            if (game.Players.Count < MinNbPlayers) return Validity.NotEnoughPlayers;
            return game.Players.Count >= MaxNbPlayers ? Validity.EnoughPlayers : Validity.Valid;
        }
        /// <summary>
        /// Verify if the hand is valid
        /// </summary>
        /// <param name="hand">The hand which is verify</param>
        /// <param name="isValid"> True if the hand is valid else false</param>
        /// <returns> Validity.Valid if the hand is valid </returns>
        public Validity IsHandValid(Hand hand, out bool isValid)
        {
            Validity valid;
            isValid = false;
            var biddings = hand.Biddings.Select(bidding => bidding.Value.Item1).ToList();

            valid = IsTakerScoreValid(hand.TakerScore);
            if (valid != Validity.Valid) return valid;
            
            valid = IsPlayersBiddingValid(biddings);
            if (valid != Validity.Valid) return valid;
            
            valid = IsChelemValid(hand);
            if (valid != Validity.Valid) return valid;
            
            isValid = true;
            return valid;
        }
        /// <summary>
        /// Verify if the taker score is valid
        /// </summary>
        /// <param name="takerScore"> The taker score </param>
        /// <returns> Validity.Valid if the taker score is valid
        /// Validity.TakerNegativeScore if the taker score is negative
        /// Validity.TakerTooMany point if the taker score is grower than 91 </returns>
        private Validity IsTakerScoreValid(int takerScore)
        {
            if (takerScore < 0) return Validity.TakerNegativeScore;
            return takerScore > 91 ? Validity.TakerTooManyPoints : Validity.Valid;
        }
        
        private Validity IsPlayersBiddingValid(IEnumerable<Bidding> iBiddings)
        {
            int nbKing = 0, nbTaker=0;
            var biddings = iBiddings.ToList();
            
            foreach (var bidding in biddings)
            {
                if (bidding == Bidding.King) ++nbKing;
                if((bidding & Bidding.Prise) == Bidding.Prise) ++nbTaker;
                if (bidding == Bidding.Unknown) return Validity.PlayerShallHaveBidding;
            }

            if (nbKing > MaxNbKing || (biddings.Count() < 5 && nbKing > 0)) return Validity.TooManyKing;
            if (nbTaker == 0) return Validity.NoTaker;
            return Validity.Valid;
        }

        private Validity IsChelemValid(Hand hand)
        {
            if (hand.Chelem is Chelem.Success or Chelem.AnnouncedSuccess &&
                hand.TakerScore != 91) return Validity.InvalidChelem;
            return Validity.Valid;
        }

        public virtual bool Equals(IRules? other)
        {
            return other != null && other.GetType() == GetType();
        }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(obj, null)) return false;

            if(ReferenceEquals(this, obj)) return true;

            return GetType() == obj.GetType() && Equals(obj as FrenchTarotRules);
        }
        
        /// <summary>
        /// Only the name need to be different for rules
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()

        {

            return GetType().Name.GetHashCode();

        }
        
        
    }
}

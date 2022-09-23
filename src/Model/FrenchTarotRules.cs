using System;
using System.Collections.Generic;
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

        public String Name => GetType().Name;

        private readonly Dictionary<int, int> _oudlersPoints = new Dictionary<int, int>()
        {
            [0] = 56,
            [1] = 51,
            [2] = 41,
            [3] = 36

        };
        private Dictionary<Bidding, int> _biddingPrice;
        private Dictionary<Bidding, int> _multiplicators = new Dictionary<Bidding, int>()
        {
        
          [Bidding.Petite] = 1,
          [Bidding.Garde] = 2,
          [Bidding.GardeSansLeChien] = 4,
          [Bidding.GardeContreLeChien] = 6,
         
        };

        private readonly Dictionary<Poignee, int> _primesPoignee = new Dictionary<Poignee, int>()
        {
            [Poignee.Simple] = 20,
            [Poignee.Double] = 30,
            [Poignee.Triple] = 40    
        };

        private Dictionary<Chelem, int> _primesChelem = new Dictionary<Chelem, int>()
        {
            [Chelem.Unknown] = 0,
            [Chelem.Success] = 200,
            [Chelem.AnnouncedSuccess] = 400,
            [Chelem.AnnouncedFail] = -200
        };
        private List<Player> _playerList;
        private int _primeAuBout;

        public int GetHandScore(Hand hand)
        {
            if (_playerList == null ||_playerList.Count < MinNbPlayers)
            {
                throw new Exception("Nombre de joueurs invalide");
            }
            if(hand == null)
            {
                throw new ArgumentException("Manche invalide");
            }

            var neededScore = 56;
            var score = hand.TakerScore;

            if (score > neededScore)
            {
                score -= neededScore;
            }


            return score;
        }

        public Validity IsGameValid(Game game)
        {
            if (game.Players.Count < MinNbPlayers) return Validity.NotEnoughPlayers;
            return game.Players.Count >= MaxNbPlayers ? Validity.EnoughPlayers : Validity.Valid;
        }

        public Validity IsHandValid(Hand hand)
        {
            Validity valid;
            List<Bidding> biddings = hand.Biddings.Select(bidding => bidding.Value.Item1).ToList();
            valid = IsPlayersBiddingValid(biddings);
            //If validity isn't valid
            if (!valid.Equals(Validity.Valid)) return valid;
            
            return valid;
        }

        private Validity IsPlayersBiddingValid(IEnumerable<Bidding> iBiddings)
        {
            int nbKing = 0, nbTaker=0;
            var biddings = iBiddings.ToList();
            
            foreach (var bidding in biddings)
            {
                if (bidding.Equals(Bidding.King)) ++nbKing;
                if((bidding & Bidding.Prise) == Bidding.Prise) ++nbTaker;
                if (bidding.Equals(Bidding.Unknown)) return Validity.PlayerShallHaveBidding;
            }

            if (nbKing > MaxNbKing || (biddings.Count() < 5 && nbKing > 0)) return Validity.TooManyKing;
            if (nbTaker == 0) return Validity.NoTaker;
            return Validity.Valid;
        }

        public virtual bool Equals(IRules other)
        {
            return other.GetType().Equals(GetType());
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null)) return false;

            if(ReferenceEquals(this, obj)) return true;

            if(GetType() != obj.GetType()) return false;

            return Equals(obj as FrenchTarotRules);
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

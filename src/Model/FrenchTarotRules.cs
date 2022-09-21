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
        
        private readonly Dictionary<int, int> _oudlersPoints = new Dictionary<int, int>();
        //private Dictionary<Bidding, int> _biddingPrice;
        //private Dictionary<Bidding, int> _multiplicators = new Dictionary<Bidding, int>()
        //{
        //
        //  [Bidding.Petite] = 1,
        //  [Bidding.Pousse] = 1,
        //  [Bidding.Garde] = 2,
        //  [Bidding.GardeSans] = 4,
        //  [Bidding.GardeContre] = 6,
        // 
        //};
        private readonly Dictionary<Poignee, int> _primesPoignee = new Dictionary<Poignee, int>();
        // private Dictionary<Chelem, int> _primesChelem;
        private List<Player> _playerList;
        private int _primeAuBout;

        public FrenchTarotRules()
        {
            //Number of points for each oudler
            _oudlersPoints.Add(0, 56);
            _oudlersPoints.Add(1, 51);
            _oudlersPoints.Add(2, 41);
            _oudlersPoints.Add(3, 36);

            // Number of points for each Bidding
            // _biddingPrice.Add(Bidding.Petite, 25);
            // _biddingPrice.Add(Bidding.Garde, 25);
            // _biddingPrice.Add(Bidding.GardeSansLeChien, 25);
            // _biddingPrice.Add(Bidding.GardeContreLeChien, 25);

            _primesPoignee.Add(Poignee.Simple, 20);
            _primesPoignee.Add(Poignee.Double, 30);
            _primesPoignee.Add(Poignee.Triple, 40);

            // Number of points for each Chelem
            // _primesChelem.Add(Chelem.Unknown,0);
            // _primesChelem.Add(Chelem.NotAnnouncedSuccess, 200);
            // _primesChelem.Add(Chelem.AnnouncedSuccess, 400);
            // _primesChelem.Add(Chelem.AnnouncedFail, -200);
            



        }
        
        public IReadOnlyDictionary<Player, int> GetHandScore(Gaming.Hand hand)
        {
            /*if (_playerList == null ||_playerList.Count < MinNbPlayers)
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
            }*/


            return new Dictionary<Player, int>();
        }

        public Validity IsGameValid(Gaming.Game game)
        {
            if (game.Players.Count < MinNbPlayers) return Validity.EnoughPlayers;
            if (game.Players.Count > MaxNbPlayers) return Validity.EnoughPlayers;
            return Validity.Valid;
        }

        public Validity IsHandValid(Gaming.Hand hand)
        {
            throw new NotImplementedException();
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

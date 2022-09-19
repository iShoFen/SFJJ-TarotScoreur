using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FrenchTarotRules : IRules
    {
        public int MinNbPlayers => throw new NotImplementedException();

        public int MaxNbPlayers => throw new NotImplementedException();

        public int MinNbPlayersForKing => throw new NotImplementedException();

        public int MaxNbKing => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        private readonly Dictionary<int, int> _oudlersPoints = new Dictionary<int, int>();
        //private Dictionary<Bidding, int> _biddingPrice;
        //private Dictionary<Bidding, int> _bidTypePrice;
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

            // Multiplicator for each BidType
            // _bidTypePrice.Add(BidType.Petite, 1);
            // _bidTypePrice.Add(BidType.Garde, 2);
            // _bidTypePrice.Add(BidType.GardeSansLeChien, 4);
            // _bidTypePrice.Add(BidType.GardeContreLeChien, 6);

            _primesPoignee.Add(Poignee.Simple, 20);
            _primesPoignee.Add(Poignee.Double, 30);
            _primesPoignee.Add(Poignee.Triple, 40);

            // Number of points for each Chelem
            // _primesChelem.Add(Chelem.Unknown,0);
            // _primesChelem.Add(Chelem.NotAnnouncedSuccess, 200);
            // _primesChelem.Add(Chelem.AnnouncedSuccess, 400);
            // _primesChelem.Add(Chelem.AnnouncedFail, -200);
            



        }
        
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

            int score = 0;
            
            
            return score;
        }

        public Validity IsGameValid(Game game)
        {
            throw new NotImplementedException();
        }

        public Validity IsHandValid(Hand hand)
        {
            throw new NotImplementedException();
        }
    }
}

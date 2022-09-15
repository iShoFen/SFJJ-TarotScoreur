using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hand
    {
        public int HandNumber { get; private set; }
        public Dictionary<Player, HandDetail> PlayerDetails { get; private set; }

        public Hand(int handNumber, Dictionary<Player, HandDetail> playerDetails)
        {
            HandNumber = handNumber;
            PlayerDetails = playerDetails;
        }
    }
}

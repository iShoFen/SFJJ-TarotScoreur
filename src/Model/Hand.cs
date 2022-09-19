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
        
        public DateTime Date { get; }

        public int TakerScore { get; }
        
        public bool TwentyOne { get; }
        
        public bool Excuse { get; }
        
        

        public Hand(int handNumber, Dictionary<Player, HandDetail> playerDetails)
        {
            HandNumber = handNumber;
            //PlayerDetails = playerDetails;
        }
    }
}

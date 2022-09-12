using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HandDetail
    {
        public int Score { get; private set; }
        public int CalculatedScore { get; private set; }
        public BidDetail BidDetail { get; private set; }
        public Poignee Poignee { get; private set; }
        public Role Role { get; private set; }

        public HandDetail(int score, int calculatedScore, BidDetail bidDetail, Poignee poignee, Role role)
        {
            Score = score;
            CalculatedScore = calculatedScore;
            BidDetail = bidDetail;
            Poignee = poignee;
            Role = role;
        }
    }
}

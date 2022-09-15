using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BidDetail
    {
        public Boolean HasWin { get; private set; }
        public Boolean Chelen { get; private set; }
        public Boolean ChelemAnnounced { get; private set; }
        public Boolean VingtEtUn { get; private set; }
        public Boolean Excuse { get; private set; }
        public Boolean Petit { get; private set; }
        public BidType BidType { get; private set; }

        public BidDetail(bool hasWin, bool chelen, bool chelemAnnounced, bool vingtEtUn, bool excuse, bool petit, BidType bidType)
        {
            HasWin = hasWin;
            Chelen = chelen;
            ChelemAnnounced = chelemAnnounced;
            VingtEtUn = vingtEtUn;
            Excuse = excuse;
            Petit = petit;
            BidType = bidType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Validity
    {
        Unknown,
        Valid,
        NotEnoughPlayers,
        EnoughPlayers,
        NoTaker,
        PlayerShallHaveBidding,
        TakerShallHaveAScore
    }
}

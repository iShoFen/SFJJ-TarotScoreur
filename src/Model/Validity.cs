using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Validity : byte
    {
        Unknown,                //0000
        Valid,                  //0001
        NotEnoughPlayers,       //0010
        EnoughPlayers,          //0011
        NoTaker,                //0100
        TooManyPlayers,         //0101
        PlayerShallHaveBidding, 
        TakerShallHaveAScore    
    }
}

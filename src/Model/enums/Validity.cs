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
        TooManyPlayers,         //0100
        NoTaker,                //0101
        TooManyKing,            //0110
        InvalidChelem,          //0111
        PlayerShallHaveBidding, //1000
        TakerShallHaveAScore,   //1001
        TakerNegativeScore,     //1010
        TakerTooManyPoints      //1011
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class Player
    {
        private sealed class PlayerFullEqComparer : EqualityComparer<Player>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override bool Equals(Player? x, Player? y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._firstName == y._firstName && x._lastName == y._lastName && x._nickName == y._nickName && x._avatar == y._avatar && x.Id == y.Id;
            }

            /// <summary>
            /// Returns the hash code of the Player
            /// </summary>
            /// <param name="obj">Player to get the hash code</param>
            /// <returns>hash code of the Player</returns>
            public override int GetHashCode(Player obj)
            {
                return HashCode.Combine(obj._firstName, obj._lastName, obj._nickName, obj._avatar, obj.Id);
            }
        }

        /// <summary>
        /// full Player equality comparer : all the properties are compared
        /// </summary>
        public static EqualityComparer<Player> FullComparer { get; } = new PlayerFullEqComparer();
    }
}

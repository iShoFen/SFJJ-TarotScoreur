namespace Model
{
    public partial class Player
    {
        private sealed class PlayerFullEqComparer : IEqualityComparer<Player>
        {
            /// <summary>
            /// equals for full player comparer
            /// </summary>
            /// <param name="x">Player to compare</param>
            /// <param name="y">Player to compare</param>
            /// <returns>true if players are equals, otherwise false</returns>
            public bool Equals(Player? x, Player? y)
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
            public int GetHashCode(Player obj)
            {
                return HashCode.Combine(obj._firstName, obj._lastName, obj._nickName, obj._avatar, obj.Id);
            }
        }

        /// <summary>
        /// full Player equality comparer : all the properties are compared
        /// </summary>
        public static IEqualityComparer<Player> PlayerFullComparer { get; } = new PlayerFullEqComparer();
    }
}

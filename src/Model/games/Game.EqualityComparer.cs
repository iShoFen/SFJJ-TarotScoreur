namespace Model.games;

public partial class Game
{
    private sealed class FullEqComparer : IEqualityComparer<Game>
    {
        /// <summary>
        /// Compares all the properties of the two games except for the Id and returns true if they are equal.
        /// </summary>
        /// <param name="x"> The first game to compare </param>
        /// <param name="y"> The second game to compare </param>
        /// <returns> True if the games are equal, false otherwise </returns>
        public bool Equals(Game? x, Game? y)
        {
            if (x is null) return false;
            if (y is  null) return false;
            if (x.Name != y.Name) return false;
            if (!Equals(x.Rules, y.Rules)) return false;
            if (x.StartDate != y.StartDate) return false;
            if (x.EndDate != y.EndDate) return false;
            if (!x.Players.SequenceEqual(y.Players)) return false;
            if (!x.Hands.SequenceEqual(y.Hands)) return false;

            return true;
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public int GetHashCode(Game obj) => 
            HashCode.Combine(obj.Name, obj.Rules, obj.StartDate, obj.EndDate) 
            ^ obj.Players.Aggregate(0, (current, key) => current ^ key.GetHashCode())
            ^ obj.Hands.Keys.Aggregate(0, (current, key) => current ^ key.GetHashCode())
            ^ obj.Hands.Values.Aggregate(0, (current, key) => current ^ key.GetHashCode());
    }
          
    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static IEqualityComparer<Game> FullComparer { get; } = new FullEqComparer();
}
namespace Model.Gaming;

public partial class Game
{
    private class FullEqComparer : EqualityComparer<Game>
    {
        /// <summary>
        /// Compares all the properties of the two games and returns true if they are equal.
        /// </summary>
        /// <param name="x"> The first game to compare </param>
        /// <param name="y"> The second game to compare </param>
        /// <returns> True if the games are equal, false otherwise </returns>
        public override bool Equals(Game? x, Game? y)
        { 
            return
                x is not null &&
                y is not null &&
                x.Id == y.Id &&
                x.Name == y.Name &&
                Equals(x.Rules, y.Rules) &&
                x.StartDate == y.StartDate &&
                x.EndDate == y.EndDate &&
                x.Players.SequenceEqual(y.Players);
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public override int GetHashCode(Game obj) => 
            HashCode.Combine(obj.Id, obj.Name, obj.Rules, obj.StartDate, obj.EndDate) 
            ^ obj.Players.Aggregate(0, (current, key) => current ^ key.GetHashCode());
    }
          
    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static EqualityComparer<Game> FullComparer { get; } = new FullEqComparer();
}
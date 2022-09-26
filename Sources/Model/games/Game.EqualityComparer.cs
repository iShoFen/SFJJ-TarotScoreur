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
            return 
                x is not null &&
                y is not null &&
                x.Name == y.Name &&
                Equals(x.Rules, y.Rules) &&
                x.StartDate == y.StartDate &&
                x.EndDate == y.EndDate &&
                x.Players.SequenceEqual(y.Players) &&
                x.Hands.SequenceEqual(y.Hands);
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public int GetHashCode(Game obj) => obj.Name.GetHashCode() % 31;
    }
          
    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static IEqualityComparer<Game> FullComparer { get; } = new FullEqComparer();
}
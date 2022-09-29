namespace Model.games;

public partial class Hand
{
    private sealed class FullEqComparer : IEqualityComparer<Hand>
    {
        /// <summary>
        /// Compares all the properties of the two hands except the Id and returns true if they are equal.
        /// </summary>
        /// <param name="x"> The first hand to compare </param>
        /// <param name="y"> The second hand to compare </param>
        /// <returns> True if the hands are equal, false otherwise </returns>
        public bool Equals(Hand? x, Hand? y)
        {
            return
                x is not null &&
                y is not null &&
                x.Number == y.Number &&
                Equals(x.Rules, y.Rules) &&
                x.Date == y.Date &&
                x.TakerScore == y.TakerScore &&
                x.Excuse == y.Excuse &&
                x.TwentyOne == y.TwentyOne &&
                x.Petit == y.Petit &&
                x.Chelem == y.Chelem &&
                x.Biddings.Keys.SequenceEqual(y.Biddings.Keys) &&
                x.Biddings.Values.SequenceEqual(y.Biddings.Values);
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public int GetHashCode(Hand obj) => obj.Number % 31;
    }

    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static IEqualityComparer<Hand> FullComparer { get; } = new FullEqComparer();
}
using Model.enums;

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
            if (x is null) return false;
            if (y is null) return false;
            if (x.HandNumber != y.HandNumber) return false;
            if (!Equals(x.Rules, y.Rules)) return false;
            if (x.Date != y.Date) return false;
            if (x.TakerScore != y.TakerScore) return false;
            if (x.Excuse != y.Excuse) return false;
            if (x.TwentyOne != y.TwentyOne) return false;
            if (x.Petit != y.Petit) return false;
            if (x.Chelem != y.Chelem) return false;
            if (!x.Biddings.Keys.SequenceEqual(y.Biddings.Keys)) return false;
            if (!x.Biddings.Values.SequenceEqual(y.Biddings.Values)) return false;

            return true;
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public int GetHashCode(Hand obj) => obj.HandNumber % 31;
    }

    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static IEqualityComparer<Hand> FullComparer { get; } = new FullEqComparer();
}
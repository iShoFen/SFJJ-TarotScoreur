namespace Model.Gaming;

public partial class Hand
{
    private class FullEqComparer : EqualityComparer<Hand>
    {
        /// <summary>
        /// Compares all the properties of the two hands and returns true if they are equal.
        /// </summary>
        /// <param name="x"> The first hand to compare </param>
        /// <param name="y"> The second hand to compare </param>
        /// <returns> True if the hands are equal, false otherwise </returns>
        public override bool Equals(Hand? x, Hand? y)
        { 
            return
                x is not null &&
                y is not null &&
                x.Id == y.Id &&
                x.HandNumber == y.HandNumber &&
                x.Date == y.Date &&
                x.Excuse == y.Excuse &&
                x.TwentyOne == y.TwentyOne &&
                x.Petit == y.Petit &&
                x.Chelem == y.Chelem &&
                x.TakerScore == y.TakerScore &&
                x.Biddings.Keys.SequenceEqual(y.Biddings.Keys) &&
                x.Biddings.Values.SequenceEqual(y.Biddings.Values);
        }

        /// <summary>
        /// Returns the hash code of the hand.
        /// </summary>
        /// <param name="obj"> The hand to get the hash code of </param>
        /// <returns> The hash code of the hand </returns>
        public override int GetHashCode(Hand obj) => 
            HashCode.Combine(obj.Id, obj.HandNumber, obj.Date, obj.Excuse, obj.TwentyOne, obj.Petit, obj.Chelem, obj.TakerScore) 
            ^ obj.Biddings.Keys.Aggregate(0, (current, key) => current ^ key.GetHashCode()) 
            ^ obj.Biddings.Values.Aggregate(0, (current, value) => current ^ value.GetHashCode());
        
    }
          
    /// <summary>
    /// The full Hand equality comparer : all the properties are compared.
    /// </summary>
    public static EqualityComparer<Hand> FullComparer { get; } = new FullEqComparer();
}
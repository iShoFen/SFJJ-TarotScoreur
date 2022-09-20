namespace Model;

public partial class Hand : EqualityComparer<Hand>
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
    public override int GetHashCode(Hand obj)
    {
        return HashCode.Combine(
            obj.HandNumber, 
            obj.Date, 
            obj.Excuse, 
            obj.TwentyOne, 
            obj.Petit, 
            obj.Chelem, 
            obj.TakerScore,
            obj.Biddings);
    }
}

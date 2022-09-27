namespace Model;

public partial class Group
{
    private sealed class GroupComparer : IEqualityComparer<Group>
    {
        public bool Equals(Group? x, Group? y)
        {
            if (x is null) return false;
            if (y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name
                   && x.Players.SequenceEqual(y.Players);
        }

        public int GetHashCode(Group obj) => obj.Name.GetHashCode();
    }

    public static IEqualityComparer<Group> GroupFullComparer { get; } = new GroupComparer();
}
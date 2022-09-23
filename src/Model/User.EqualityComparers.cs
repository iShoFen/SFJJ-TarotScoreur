namespace Model;

public partial class User
{
    private sealed class UserFullEqComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return PlayerFullComparer.Equals(x, y) && x.Email.Equals(y.Email) && x.Password.Equals(y.Password);
        }

        public int GetHashCode(User obj) =>
            HashCode.Combine(PlayerFullComparer.GetHashCode(obj), obj.Email, obj.Password);
    }

    public static IEqualityComparer<User> UserEqualityComparer { get; } = new UserFullEqComparer();
}
namespace Model;

/// <summary>
/// a User of the application
/// </summary>
public partial class User : Player, IEquatable<User>
{
    /// <summary>
    /// email address of the User
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// password of the User
    /// </summary>
    public string Password { get; }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="firstName">first name of this Player</param>
    /// <param name="lastName">last name of this Player</param>
    /// <param name="nickName">nickname of this Player</param>
    /// <param name="avatar">file name of the avatar of this Player</param>
    /// <param name="email">email of this Player</param>
    /// <param name="password">password of this Player</param>
    public User(string firstName, string lastName, string nickName, string avatar, string email, string password) :
        base(firstName, lastName, nickName, avatar)
    {
        Email = email;
        Password = password;
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="id">id of this Player</param>
    /// <param name="firstName">first name of this Player</param>
    /// <param name="lastName">last name of this Player</param>
    /// <param name="nickName">nickname of this Player</param>
    /// <param name="avatar">file name of the avatar of this Player</param>
    /// <param name="email">email of this Player</param>
    /// <param name="password">password of this Player</param>
    public User(ulong id, string firstName, string lastName, string nickName, string avatar, string email,
        string password) : base(id, firstName, lastName, nickName, avatar)
    {
        Email = email;
        Password = password;
    }

    public bool Equals(User? other)
    {
        if (other is null) return false;
        if (Id == 0 || other.Id == 0) return PlayerFullComparer.Equals(this, other);
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as User);
    }

    public override int GetHashCode() => Id == 0 ? UserEqualityComparer.GetHashCode(this) : Id.GetHashCode();

    public override string ToString() => $"{base.ToString()}: {Email}";
}
namespace Model;

/// <summary>
/// a User of the application
/// </summary>
public class User : Player, IEquatable<User>
{
    /// <summary>
    /// email address of the User
    /// </summary>
    public string Email { get; protected set; }

    /// <summary>
    /// password of the User
    /// </summary>
    public string Password { get; protected set; }

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
    /// 
    /// </summary>
    /// <param name="id">id of this Player</param>
    /// <param name="firstName">first name of this Player</param>
    /// <param name="lastName">last name of this Player</param>
    /// <param name="nickName">nickname of this Player</param>
    /// <param name="avatar">file name of the avatar of this Player</param>
    /// <param name="email">email of this Player</param>
    /// <param name="password">password of this Player</param>
    public User(long id, string firstName, string lastName, string nickName, string avatar, string email,
        string password) : base(id, firstName, lastName, nickName, avatar)
    {
        Email = email;
        Password = password;
    }

    public bool Equals(User? other)
    {
        return base.Equals(other) && Email.Equals(other.Email) && Password.Equals(other.Password);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals(obj as User);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() + Email.GetHashCode() + Password.GetHashCode();
    }

    public override string ToString()
    {
        return $"{base.ToString()}: {Email}";
    }
}
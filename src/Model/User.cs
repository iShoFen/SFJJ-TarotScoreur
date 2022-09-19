namespace Model;

/// <summary>
/// a User of the application
/// </summary>
public class User : Player
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

    //TODO Hashcode and Equals and Equals by IEquatable
}
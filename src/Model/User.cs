namespace Model;

public class User : Player
{
    public string Email { get; protected set; }
    public string Password { get; protected set; }

    public User(string firstName, string lastName, string nickName, string avatar, string email, string password) :
        base(firstName, lastName, nickName, avatar)
    {
        Email = email;
        Password = password;
    }

    public User(long id, string firstName, string lastName, string nickName, string avatar, string email,
        string password) : base(id, firstName, lastName, nickName, avatar)
    {
        Email = email;
        Password = password;
    }
}
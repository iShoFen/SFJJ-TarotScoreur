namespace RestController.DTOs;

public class UserDetailDTO : IEquatable<UserDetailDTO>
{
    /// <summary>
    /// Id of the User
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// First name of the User
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Last name of the User
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Nickname of the User
    /// </summary>
    public string Nickname { get; set; } = null!;

    /// <summary>
    /// Avatar of the User
    /// </summary>
    public string Avatar { get; set; } = null!;

    /// <summary>
    /// Email of the User
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Games of the user
    /// </summary>
    public ICollection<ulong> Games { get; set; } = new List<ulong>();
    /// <summary>
    /// Groups of the user
    /// </summary>
    public ICollection<ulong> Groups { get; set; } = new List<ulong>();

    public bool Equals(UserDetailDTO? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName && Nickname == other.Nickname && Avatar == other.Avatar && Email == other.Email && Games.SequenceEqual(other.Games) && Groups.SequenceEqual(other.Groups);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserDetailDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Nickname, Avatar, Email, Games, Groups);
    }
}
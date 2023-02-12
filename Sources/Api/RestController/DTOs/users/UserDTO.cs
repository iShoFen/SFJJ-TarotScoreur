namespace RestController.DTOs;

/**
 * DTO for the User table
 */
public class UserDTO
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

    protected bool Equals(UserDTO other)
    {
        return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName && Nickname == other.Nickname && Avatar == other.Avatar && Email == other.Email;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((UserDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Nickname, Avatar, Email);
    }
}
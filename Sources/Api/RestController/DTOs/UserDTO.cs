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
    /// All the Games the User has played
    /// </summary>
    public ICollection<ulong> Games { get; set; } = new HashSet<ulong>();

    /// <summary>
    /// All the Groups of the User
    /// </summary>
    public ICollection<ulong> Groups { get; set; } = new HashSet<ulong>();
    
    /// <summary>
    /// Email of the User
    /// </summary>
    public string Email { get; set; } = null!;
}
namespace RestController.DTOs;

public class UserInsertRequest
{
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
    /// Password of the User
    /// </summary>
    public string Password { get; set; } = null!;
}
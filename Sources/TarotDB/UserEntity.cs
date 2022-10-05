namespace TarotDB;

/// <summary>
/// a UserEntity in the database
/// </summary>
internal class UserEntity : PlayerEntity
{
    /// <summary>
    /// Email of the UserEntity
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Password of the UserEntity
    /// </summary>
    public string Password { get; set; }
}
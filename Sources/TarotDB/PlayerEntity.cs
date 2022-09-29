using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Tarot2B2Model")]

namespace TarotDB;

/// <summary>
/// A PlayerEntity in the database
/// </summary>
internal class PlayerEntity
{
    /// <summary>
    /// Id of the PlayerEntity
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// First name of the PlayerEntity
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of the PlayerEntity
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Nickname of the PlayerEntity
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// Avatar of the PlayerEntity
    /// </summary>
    public string Avatar { get; set; }
}
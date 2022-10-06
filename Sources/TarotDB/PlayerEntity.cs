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
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Last name of the PlayerEntity
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Nickname of the PlayerEntity
    /// </summary>
    public string Nickname { get; set; } = null!;

    /// <summary>
    /// Avatar of the PlayerEntity
    /// </summary>
    public string Avatar { get; set; } = null!;

    /// <summary>
    /// All the Games the PlayerEntity has played
    /// </summary>
    public ICollection<GameEntity> Games { get; set; } = new HashSet<GameEntity>();

    /// <summary>
    /// All the Biddings done by the PlayerEntity
    /// </summary>
    public ICollection<BiddingPoigneeEntity> Biddings { get; set; } = new HashSet<BiddingPoigneeEntity>();
}
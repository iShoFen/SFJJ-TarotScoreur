namespace TarotDB;

/// <summary>
/// Represents a Game in the Database
/// </summary>
internal class GameEntity
{
    /// <summary>
    /// The unique identifier for the game
    /// </summary>
    public ulong Id { get; set; }
    
    /// <summary>
    /// The name of the Rules used for the game
    /// </summary>
    public string Rules { get; set; } = null!;
    
    /// <summary>
    /// The name of the Game
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// The start date of the game
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// The end date of the game
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// The players in the game
    /// </summary>
    public ICollection<PlayerEntity> Players { get; set; } = new HashSet<PlayerEntity>();
    
    /// <summary>
    /// The rounds in the game
    /// </summary>
    public ICollection<HandEntity> Hands { get; set; } = new HashSet<HandEntity>();
}
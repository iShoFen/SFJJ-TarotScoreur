namespace RestController.DTOs.games;

public class GameDTO
{
    /// <summary>
    /// The unique identifier for the Game
    /// </summary>
    public ulong Id { get; set; }
    
    /// <summary>
    /// The name of the Rules used for the Game
    /// </summary>
    public string Rules { get; set; } = null!;
    
    /// <summary>
    /// The name of the Game
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// The start date of the Game
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// The end date of the Game
    /// </summary>
    public DateTime? EndDate { get; set; }
}
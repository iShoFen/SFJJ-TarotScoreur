namespace RestController.DTOs;

public class GameDTOPostRequest
{
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
    
    /// <summary>
    /// The Users in the Game
    /// </summary>
    public ICollection<ulong> Users { get; set; } = new HashSet<ulong>();
    
}
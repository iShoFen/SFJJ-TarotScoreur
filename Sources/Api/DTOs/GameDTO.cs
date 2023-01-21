namespace DTOs;

public class GameDTO
{
    /// <summary>
    /// The unique identifier for the Game
    /// </summary>
    public long Id { get; set; }
    
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
    public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
    
    /// <summary>
    /// The Hands in the Game
    /// </summary>
    public ICollection<HandDTO> Hands { get; set; } = new HashSet<HandDTO>();
}
namespace RestController.DTOs.Games;

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

    protected bool Equals(GameDTO other)
    {
        return Id == other.Id && Rules == other.Rules && Name == other.Name && StartDate.Equals(other.StartDate) && Nullable.Equals(EndDate, other.EndDate);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GameDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Rules, Name, StartDate, EndDate);
    }
}
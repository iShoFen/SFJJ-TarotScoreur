namespace RestController.DTOs.Games;

public class GameDetailDTO
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
    
    /// <summary>
    /// The Users in the Game
    /// </summary>
    public ICollection<ulong> Users { get; set; } = new HashSet<ulong>();
    
    /// <summary>
    /// The Hands in the Game
    /// </summary>
    public ICollection<ulong> Hands { get; set; } = new HashSet<ulong>();

    public bool Equals(GameDetailDTO other)
    {
        return Id == other.Id && Rules == other.Rules && Name == other.Name && StartDate.Equals(other.StartDate) && Nullable.Equals(EndDate, other.EndDate) && Users.SequenceEqual(other.Users) && Hands.SequenceEqual(other.Hands);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GameDetailDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Rules, Name, StartDate, EndDate, Users, Hands);
    }
}
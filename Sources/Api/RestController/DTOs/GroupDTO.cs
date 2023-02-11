namespace RestController.DTOs;

/**
 * DTO for the Group table.
 */
public class GroupDTO : IEquatable<GroupDTO>
{
    /// <summary>
    /// Id of the Group.
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// Name of the Group.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Users of the Group.
    /// </summary>
    public ICollection<ulong> Users { get; set; } = new HashSet<ulong>();

    public bool Equals(GroupDTO? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Name == other.Name && Users.SequenceEqual(other.Users);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((GroupDTO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Users);
    }
}
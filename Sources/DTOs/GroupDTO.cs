namespace DTOs;

/**
 * DTO for the Group table.
 */
public class GroupDTO
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
    public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
}
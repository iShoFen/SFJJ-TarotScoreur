namespace DTOs;

/**
 * DTO for the Group table.
 */
public class GroupDto
{
    /// <summary>
    /// Id of the Group.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Name of the Group.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Users of the Group.
    /// </summary>
    public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
}
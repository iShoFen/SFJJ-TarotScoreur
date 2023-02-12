namespace RestController.DTOs;

public class GroupDTOPostRequest
{
    /// <summary>
    /// Name of the Group.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Users of the Group.
    /// </summary>
    public ICollection<ulong> Users { get; set; } = new HashSet<ulong>();
}
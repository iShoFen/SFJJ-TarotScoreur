using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace TarotDB;

/// <summary>
/// A GroupEntity in the database
/// </summary>
internal class GroupEntity
{
    /// <summary>
    /// Id of the GroupEntity
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// Name of the GroupEntity
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Players of the GroupEntity
    /// </summary>
    public ICollection<PlayerEntity> Players { get; set; } = new HashSet<PlayerEntity>();
}
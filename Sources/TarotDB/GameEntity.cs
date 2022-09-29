namespace TarotDB;

internal class GameEntity
{
    public ulong Id { get; set; }
    // IRules
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<PlayerEntity> Players { get; set; }
    public ICollection<HandEntity> Hands { get; set; }
}
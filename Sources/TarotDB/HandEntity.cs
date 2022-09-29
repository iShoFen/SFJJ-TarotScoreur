using Model.enums;

namespace TarotDB;

internal class HandEntity
{
    public ulong Id { get; set; }
    public uint Number { get; set; }
    // Rules
    public DateTime Date { get; set; }
    public uint TakerScore { get; set; }
    public bool? TwentyOne { get; set; }
    public bool? Excuse { get; set; }
    public PetitResult Petit { get; set; }
    public Chelem Chelem { get; set; }
    // Dictionary<Player, (Bidding, Poignee)>

}

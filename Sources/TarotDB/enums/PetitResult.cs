namespace TarotDB.enums;

[Flags]
public enum PetitResult : byte
{
    /// <summary>
    /// Unknown status of the Petit
    /// </summary>
    Unknown = 0,                    // 0000 0000

    /// <summary>
    /// Petit Owned by the taker
    /// </summary>
    Owned = 1,                      // 0000 0001
    
    /// <summary>
    /// Petit Not owned by the taker
    /// </summary>
    NotOwned = 2,                   // 0000 0010
    
    /// <summary>
    /// Petit lost by the taker
    /// </summary>
    Lost = 4,                       // 0000 0100
    
    /// <summary>
    /// Petit AuBout in the hand (shall not be set directly, but through AuboutOwned, LostAubout)
    /// </summary>
    AuBout = 8,                     // 0000 1000
    /// <summary>
    /// Petit Aubout by the taker
    /// </summary>
    AuBoutOwned = Owned | AuBout,    // 0000 1001
    /// <summary>
    /// Petit AuBout by the defence
    /// </summary>
    LostAuBout = Lost | AuBout     // 0000 1101
    
}
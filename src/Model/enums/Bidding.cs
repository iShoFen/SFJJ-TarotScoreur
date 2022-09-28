namespace Model.enums;

[Flags]
public enum Bidding : byte
{    
    /// <summary>
    /// Unknown bidding
    /// </summary>
    Unknown = 0,                        // 0000 0000
    
    /// <summary>
    ///  A bidding (shall not be set directly, but through Petites, Garde, GardeSansLeChien, GardeContreLeChien)
    /// </summary>
    Prise = 1,                          // 0000 0001
    
    /// <summary>
    /// Petite (also a Prise)
    /// </summary>
    Petite = Prise | 2,                 // 0000 0011
    
    /// <summary>
    /// Garde (also a Prise)
    /// </summary>
    Garde = Prise | 4,                  // 0000 0101
    
    /// <summary>
    /// Garde sans le chien (also a Prise)
    /// </summary>
    GardeSansLeChien = Prise | 6,       // 0000 0111
    
    /// <summary>
    /// Garde contre le chien (also a Prise)
    /// </summary>
    GardeContreLeChien = Prise | 8,     // 0000 1001
    
    /// <summary>
    /// An opponent of the Taker
    /// </summary>
    Opponent = 16,                      // 0001 0000
    
    /// <summary>
    /// A King Called by the Taker
    /// </summary>
    King = 32                           // 0010 0000
}
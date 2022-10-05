namespace TarotDB.enums;

public enum ChelemDB : byte
{
    /// <summary>
    /// Unknown ChelemDB
    /// </summary>
    Unknown = 0,                                // 0000 0000
    
    /// <summary>
    /// If the ChelemDB as been announced (shall not be used directly, prefer use AnnouncedSuccess or AnnouncedFail)
    /// </summary>
    Announced = 1,                              // 0000 0001
    
    /// <summary>
    /// If the ChelemDB is a success (shall not be used directly, prefer use NotAnnouncedSuccess or AnnouncedSuccess)
    /// </summary>
    Success = 2,                                // 0000 0010
    
    /// <summary>
    /// If the ChelemDB is a fail (shall not be used directly, prefer use AnnouncedFail)
    /// </summary>
    Fail = 4,                                   // 0000 0100
    
    /// <summary>
    /// If the ChelemDB is a success and hasn't been announced
    /// </summary>
    NotAnnouncedSuccess = Success,              // 0000 0010
    
    /// <summary>
    /// If the ChelemDB is a success and has been announced
    /// </summary>
    AnnouncedSuccess = Announced | Success,     // 0000 0011
    
    /// <summary>
    /// If the ChelemDB is a fail and has been announced
    /// </summary>
    AnnouncedFail = Announced | Fail            // 0000 0101
}
namespace RestController.DTOs.Enums;

    public enum PoigneeDTO : byte
    {
        /// <summary>
        /// If the player has no poignee
        /// </summary>
        None = 0,       // 0000 0000
        
        /// <summary>
        /// If the player has a simple poignee (10 atouts)
        /// </summary>
        Simple = 1,     // 0000 0001
        
        /// <summary>
        /// If the player has a double poignee (13 atouts)
        /// </summary>
        Double = 2,     // 0000 0010
        
        /// <summary>
        /// If the player has a triple poignee (15 atouts)
        /// </summary>
        Triple = 3  // 0000 0011
    }

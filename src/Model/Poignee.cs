using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Poignee : byte
    {
        /// <summary>
        /// If the player has no poignee
        /// </summary>
        None = 0, // 0000
        
        /// <summary>
        /// If the player has a simple poignee (10 atouts)
        /// </summary>
        Simple = 1, // 0001
        
        /// <summary>
        /// If the player has a double poignee (13 atouts)
        /// </summary>
        Double = 2, // 0010
        
        /// <summary>
        /// If the player has a triple poignee (15 atouts)
        /// </summary>
        Triple = 3 // 0011
    }
}

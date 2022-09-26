using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RulesFactory
    {
        /// <summary>
        /// Dictionnary of different rules in the game Tarot
        /// </summary>
        public ReadOnlyDictionary<string, IRules> Rules { get; private set; }

    }
}

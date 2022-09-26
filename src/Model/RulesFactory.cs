using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class RulesFactory
    {
        /// <summary>
        /// Dictionnary of different rules in the game Tarot
        /// </summary>
        public static ReadOnlyDictionary<string, IRules> Rules { get; private set; }

        private static Dictionary<string,IRules> _rules = new Dictionary<string, IRules>();

        static RulesFactory()
        {
            _rules.Add(new FrenchTarotRules().Name,new FrenchTarotRules());
            Rules = new ReadOnlyDictionary<string, IRules>(_rules);
        }
        
        public static IRules? Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !Rules.TryGetValue(name, out var value))
            {
                return null;
            }
            return value;
        }

    }
}

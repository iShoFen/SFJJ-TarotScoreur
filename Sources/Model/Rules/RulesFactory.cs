using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Rules
{
    /// <summary>
    /// Factory class for creating a new instance of a  IRules
    ///  <see cref="IRules"/>.
    /// </summary>
    public static class RulesFactory
    {
        /// <summary>
        /// Dictionary of different rules in the game Tarot
        /// </summary>
        public static ReadOnlyDictionary<string, IRules> Rules { get; }
        private static readonly Dictionary<string,IRules> PRules = new();

        /// <summary>
        /// Static constructor for the RulesFactory class
        /// </summary>
        static RulesFactory()
        {
            PRules.Add(new FrenchTarotRules().Name,new FrenchTarotRules());
            Rules = new ReadOnlyDictionary<string, IRules>(PRules);
        }
        
        /// <summary>
        /// Create a new instance of a  IRules
        /// </summary>
        /// <param name="name"> Name of the rules to create </param>
        /// <returns> A new instance of a  IRules </returns>
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

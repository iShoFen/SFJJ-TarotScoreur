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
        public ReadOnlyDictionary<string, IRules> Rules { get; private set; }

    }
}

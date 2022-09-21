using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game : IEquatable<Game>
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Hand> Hands { get; private set; }

        public Game(long id, string name, DateTime startDate, DateTime endDate, List<Player> players, List<Hand> hands)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Players = players;
            Hands = hands;
        }

        public bool Equals(Game? other)
        {
            return Name.Equals(other?.Name) && StartDate.Equals(other?.StartDate) && EndDate.Equals(other?.EndDate);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as Game);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + StartDate.GetHashCode() + EndDate.GetHashCode();
        }

        public override string ToString()
        {
            return $"({Id}) {Name} {StartDate} {EndDate}";
        }
    }
}

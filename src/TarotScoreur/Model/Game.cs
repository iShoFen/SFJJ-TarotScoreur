using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
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
    }
}

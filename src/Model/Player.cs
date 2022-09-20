using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }

        public Player(long id, string firstName, string lastName, string nickName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}

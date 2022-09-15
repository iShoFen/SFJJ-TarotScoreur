using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public long id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }

        public Player(long id, string firstName, string lastName, string nickName)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}

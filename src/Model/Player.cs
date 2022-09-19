using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public long Id { get; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string NickName { get; protected set; }
        public string Avatar { get; protected set; }

        public Player(string firstName, string lastName, string nickName, string avatar)
        {
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Avatar = avatar;
        }

        public Player(long id, string firstName, string lastName, string nickName, string avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Avatar = avatar;
        }
    }
}
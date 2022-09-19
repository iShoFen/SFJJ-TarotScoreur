using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// a Player of the Tarot game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// id of this Player
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// first name of this Player
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// last name of this Player
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// nickname of this Player
        /// </summary>
        public string NickName { get; protected set; }

        /// <summary>
        /// file name of the avatar of this Player
        /// </summary>
        public string Avatar { get; protected set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="firstName">first name of this Player</param>
        /// <param name="lastName">last name of this Player</param>
        /// <param name="nickName">nickname of this Player</param>
        /// <param name="avatar">file name of the avatar of this Player</param>
        public Player(string firstName, string lastName, string nickName, string avatar)
        {
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Avatar = avatar;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id">id of this Player</param>
        /// <param name="firstName">first name of this Player</param>
        /// <param name="lastName">last name of this Player</param>
        /// <param name="nickName">nickname of this Player</param>
        /// <param name="avatar">file name of the avatar of this Player</param>
        public Player(long id, string firstName, string lastName, string nickName, string avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Avatar = avatar;
        }

        //TODO Hashcode and Equals and Equals by IEquatable
    }
}
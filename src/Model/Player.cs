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
    public class Player : IEquatable<Player>
    {
        /// <summary>
        /// id of this Player
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// first name of this Player
        /// </summary>
        public string FirstName
        {
            get => firstName;
            protected set
            {
                firstName = string.IsNullOrWhiteSpace(value) ? "" : value;
            }
        }
        private string firstName;

        /// <summary>
        /// last name of this Player
        /// </summary>
        public string LastName
        {
            get => lastName;
            protected set
            {
                lastName = string.IsNullOrWhiteSpace(value) ? "" : value;
            }
        }
        private string lastName;

        /// <summary>
        /// nickname of this Player
        /// </summary>
        public string NickName
        {
            get => nickName;
            protected set
            {
                nickName = string.IsNullOrWhiteSpace(value) ? "" : value;
            }
        }
        private string nickName;

        /// <summary>
        /// file name of the avatar of this Player
        /// </summary>
        public string Avatar
        {
            get => avatar;
            protected set
            {
                avatar = string.IsNullOrWhiteSpace(value) ? "" : value;
            }
        }
        private string avatar;

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

            if (string.IsNullOrWhiteSpace(FirstName)
                && string.IsNullOrWhiteSpace(LastName)
                && string.IsNullOrWhiteSpace(NickName))
            {
                throw new ArgumentException("A Player must have at least one first name or last name or nick name");
            }
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
            : this(firstName, lastName, nickName, avatar)
        {
            Id = id;
        }

        public bool Equals(Player? other)
        {
            return FirstName.Equals(other?.FirstName) && LastName.Equals(other?.LastName) && NickName.Equals(other?.NickName);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as Player);
            
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + NickName.GetHashCode();
        }

        public override string ToString()
        {
            return $"({Id}) {FirstName} {LastName} \"{NickName}\"";
        }
    }
}
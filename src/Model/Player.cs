namespace Model
{
    /// <summary>
    /// a Player of the Tarot game
    /// </summary>
    public partial class Player : IEquatable<Player>
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
            get => _firstName;
            protected set => _firstName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }
        private string _firstName;

        /// <summary>
        /// last name of this Player
        /// </summary>
        public string LastName
        {
            get => _lastName;
            protected set => _lastName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }
        private string _lastName;

        /// <summary>
        /// nickname of this Player
        /// </summary>
        public string NickName
        {
            get => _nickName;
            protected set => _nickName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }
        private string _nickName;

        /// <summary>
        /// file name of the avatar of this Player
        /// </summary>
        public string Avatar
        {
            get => _avatar;
            protected set => _avatar = string.IsNullOrWhiteSpace(value) ? "" : value;
        }
        private string _avatar;

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
            if (other is null) return false;
            if (Id != 0) return Id == other.Id;
            return other.Id == 0 && FullComparer.Equals(this, other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as Player);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, NickName);
        }

        public override string ToString()
        {
            return $"({Id}) {FirstName} {LastName} \"{NickName}\"";
        }
    }
}
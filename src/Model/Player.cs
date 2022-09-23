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
        public long Id { get; }

        /// <summary>
        /// first name of this Player
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            private init => _firstName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }

        private readonly string _firstName;

        /// <summary>
        /// last name of this Player
        /// </summary>
        public string LastName
        {
            get => _lastName;
            private init => _lastName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }

        private readonly string _lastName;

        /// <summary>
        /// nickname of this Player
        /// </summary>
        public string NickName
        {
            get => _nickName;
            private init => _nickName = string.IsNullOrWhiteSpace(value) ? "" : value;
        }

        private readonly string _nickName;

        /// <summary>
        /// file name of the avatar of this Player
        /// </summary>
        public string Avatar
        {
            get => _avatar;
            private init => _avatar = string.IsNullOrWhiteSpace(value) ? "" : value;
        }

        private readonly string _avatar;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="firstName">first name of this Player</param>
        /// <param name="lastName">last name of this Player</param>
        /// <param name="nickName">nickname of this Player</param>
        /// <param name="avatar">file name of the avatar of this Player</param>
        public Player(string firstName, string lastName, string nickName, string avatar)
        {
            if ((string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)) &&
                string.IsNullOrWhiteSpace(nickName))
            {
                throw new ArgumentException(
                    "A player must have a first name and a last name if he do not have a nickname");
            }

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
            : this(firstName, lastName, nickName, avatar)
        {
            Id = id;
        }

        public bool Equals(Player? other)
        {
            if (other is null) return false;
            if (Id != 0) return Id == other.Id;
            return other.Id == 0 && PlayerFullComparer.Equals(this, other);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals(obj as Player);
        }

        public override int GetHashCode() => Id == 0 ? PlayerFullComparer.GetHashCode() : Id.GetHashCode();

        public override string ToString() => $"({Id}) {FirstName} {LastName} \"{NickName}\"";
    }
}
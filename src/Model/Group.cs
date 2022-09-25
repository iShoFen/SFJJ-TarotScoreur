using System.Collections.ObjectModel;

namespace Model;

public class Group
{
    /// <summary>
    /// id of the Group
    /// </summary>
    public ulong Id { get; }

    /// <summary>
    /// name of the Group
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Players of the Group
    /// </summary>
    public ReadOnlyCollection<Player> Players { get; }
    private readonly List<Player> _players = new();

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="name">name of the Group</param>
    /// <param name="players">players to add in the Group</param>
    public Group(string name, params Player[] players)
        : this(0, name, players)
    { }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="id">id of the Group</param>
    /// <param name="name">name of the Group</param>
    /// <param name="players">players to add in the Group</param>
    public Group(ulong id, string name, params Player[] players)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("the group must have a name");
        }

        Id = id;
        Name = name;
        AddPlayers(players);
        Players = new ReadOnlyCollection<Player>(_players);
    }

    /// <summary>
    /// adds a player in this Group
    /// </summary>
    /// <param name="player">player to add</param>
    /// <exception cref="ArgumentException">if the player is null</exception>
    public bool AddPlayer(Player player)
    {
        if (player == null)
        {
            throw new ArgumentException("Cannot add player because it is null");
        }
        if (_players.Contains(player))
        {
            return false;
        }
        _players.Add(player);
        return true;
    }

    /// <summary>
    /// adds a range of Player in this Group
    /// </summary>
    /// <param name="players">players to add</param>
    public bool AddPlayers(params Player[] players)
    {
        var canAllBeAdded = players.Any(player => _players.Contains(player));
        return !canAllBeAdded && players.All(AddPlayer);
    }

    /// <summary>
    /// removes a player in this Group
    /// </summary>
    /// <param name="player">player to remove</param>
    public bool RemovePlayer(Player player)
    {
        return _players.Remove(player);
    }

    /// <summary>
    /// clear the players of this Group
    /// </summary>
    public void ClearPlayers()
    {
        _players.Clear();
    }
}
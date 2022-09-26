using System.Collections.ObjectModel;

namespace Model;

public class Group
{
    /// <summary>
    /// name of the Group
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Players of the Group
    /// </summary>
    public ReadOnlyCollection<Player> Players { get; }
    private readonly HashSet<Player> _players = new();

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="name">name of the Group</param>
    public Group(string name)
    {
        Name = name;
        Players = new ReadOnlyCollection<Player>(_players.ToList());
    }

    /// <summary>
    /// adds a player in this Group
    /// </summary>
    /// <param name="player">player to add</param>
    /// <exception cref="ArgumentException">if the player is null</exception>
    public void AddPlayer(Player player)
    {
        if (player == null)
        {
            throw new ArgumentException("Cannot add player because it is null");
        }
        _players.Add(player);
    }

    /// <summary>
    /// removes a player in this Group
    /// </summary>
    /// <param name="player">player to remove</param>
    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }

    /// <summary>
    /// clear the players of this Group
    /// </summary>
    public void ClearPlayers()
    {
        _players.Clear();
    }
}
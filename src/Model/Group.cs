using System.Collections.ObjectModel;

namespace Model;

public class Group
{
    public string Name { get; private set; }
    
    public ReadOnlyCollection<Player> Players { get; }
    private readonly HashSet<Player> _players = new();

    public Group(string name)
    {
        Name = name;
        Players = new ReadOnlyCollection<Player>(_players.ToList());
    }

    public void AddPlayer(Player player)
    {
        if (player == null)
        {
            throw new ArgumentException("Cannot add player because it is null");
        }
        _players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }
}
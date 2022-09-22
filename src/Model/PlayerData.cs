using System.Collections.ObjectModel;
using Model.games;
namespace Model;

public class PlayerData : IEquatable<PlayerData>
{
    /**
     * References the player who owns the data
     */
    public Player Player { get; internal set; }

    public ReadOnlyCollection<Game> Games { get; private set; }
    private readonly HashSet<Game> _games = new();

    public int WinCount { get; internal set; }

    public int LossCount { get; internal set; }

    public int GameCount => _games.Count;

    public PlayerData(Player player, int winCount, int lossCount)
    {
        Player = player;
        WinCount = winCount;
        LossCount = lossCount;
        Games = new ReadOnlyCollection<Game>(_games.ToList());
    }

    public PlayerData AddGame(Game game)
    {
        if(game == null)
        {
            throw new ArgumentNullException("Game is null");
        }
        _games.Add(game);
        return this;
    }

    public bool Equals(PlayerData? other)
    {
        return Player.Equals(other.Player);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals(obj as PlayerData);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Player);
    }
}
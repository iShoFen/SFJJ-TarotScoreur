using System.Collections.ObjectModel;
using Model.games;
namespace Model;

public class PlayerData : IEquatable<PlayerData>
{
    /**
     * References the player who owns the data
     */
    public Player Player { get; }

    public ReadOnlyCollection<Game> Games { get; }
    private readonly List<Game> _games = new();

    public int WinCount { get; }

    public int LossCount { get; }

    public int GameCount => _games.Count;

    public PlayerData(Player player, int winCount, int lossCount)
    {
        Player = player;
        WinCount = winCount;
        LossCount = lossCount;
        Games = new ReadOnlyCollection<Game>(_games);
    }

    public PlayerData AddGame(Game? game)
    {
        if (game is null)
        {
            throw new ArgumentNullException(nameof(game), "Game is null");
        }
        _games.Add(game);
        return this;
    }

    public bool Equals(PlayerData? other)
    {
        return Player.Equals(other?.Player);
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
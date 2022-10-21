using System.Collections.ObjectModel;
using Model.games;
namespace Model;

public sealed class PlayerData : IEquatable<PlayerData>
{
    /**
     * References the player who owns the data
     */
    public Player Player { get; }

    public int WinCount { get; }

    public int LossCount { get; }
    
    public int HandCount { get; }
    
    public int GameCount { get; }

    public PlayerData(Player player, int winCount, int lossCount, int handCount, int gameCount)
    {
        Player = player;
        WinCount = winCount;
        LossCount = lossCount;
        HandCount = handCount;
        GameCount = gameCount;
    }

    public bool Equals(PlayerData? other) => Player.Equals(other?.Player);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals(obj as PlayerData);
    }

    public override int GetHashCode() => HashCode.Combine(Player);
}
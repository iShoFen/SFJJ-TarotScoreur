using Model.Enums;
using Model.Games;
using Model.Players;

namespace Model.Rules;

/// <summary>
/// Interface for the basic rules logic
/// </summary>
public interface IRules
{
    /// <summary>
    /// Minimum number  of players needed to play a game with these rules
    /// </summary>
    int MinNbPlayers { get; }
    /// <summary>
    /// Maximum number of players needed to play a game with these rules
    /// </summary>
    int MaxNbPlayers { get; }
    /// <summary>
    /// Minimum number of players for call a king in a game with these rules
    /// </summary>
    int MinNbPlayersForKing { get; }
    /// <summary>
    /// Maximum number of players called for king to play a game with these rules
    /// </summary>
    int MaxNbKing { get; }
    /// <summary>
    /// Name of these rules
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Check is the game is valid
    /// </summary>
    /// <param name="game"> Game to check </param>
    /// <returns> The validity of the game </returns>
    public Validity IsGameValid(Game game);
    /// <summary>
    /// Check if the hand is valid
    /// </summary>
    /// <param name="hand"> Hand to check </param>
    /// <param name="isValid"> Boolean to know if the hand is valid </param>
    /// <returns> The validity of the hand </returns>
    public Validity IsHandValid(Hand hand, out bool isValid);
    /// <summary>
    /// Calculate the score for a hand
    /// </summary>
    /// <param name="hand"> Hand to calculate the score </param>
    /// <returns> The score of each player in the hand </returns>
    public IReadOnlyDictionary<Player,int> GetHandScore(Hand hand);
}
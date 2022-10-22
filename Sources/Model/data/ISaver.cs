using Model.games;

namespace Model.data;

public interface ISaver
{
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    /// <returns>The player saved</returns>
    Task<Player?> SavePlayer(Player player);

    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    /// <returns>The game saved</returns>
    Task<Game?> SaveGame(Game game);

    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    /// <returns>The group saved</returns>
    Task<Group?> SaveGroup(Group group);
}
using Model.games;

namespace Model.data;

public interface ISaver
{
    /// <summary>
    ///Save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    /// <returns>The player saved</returns>
    Task<Player?> SavePlayer(Player player);

    /// <summary>
    ///Save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    /// <returns>The game saved</returns>
    Task<Game?> SaveGame(Game game);

    /// <summary>
    ///Save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    /// <returns>The group saved</returns>
    Task<Group?> SaveGroup(Group group);
}
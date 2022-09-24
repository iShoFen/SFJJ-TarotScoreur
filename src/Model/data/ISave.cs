namespace Model.data;

public interface ISave
{
    /// <summary>
    /// Method to save a player
    /// </summary>
    /// <param name="player">Player to register</param>
    void SavePlayer(Player player);
    
    /// <summary>
    /// Method to save a game
    /// </summary>
    /// <param name="game">Game to register</param>
    void SaveGame(Game game);
    
    /// <summary>
    /// Method to save a group
    /// </summary>
    /// <param name="group">Group to register</param>
    void SaveGroup(Group group);
}
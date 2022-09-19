namespace Model;

public class PlayerData
{
    /**
     * References the player who owns the data
     */
    public Player Player { get; private set; }
    
    public int WinCount { get; private set; }
    
    public int LossCount { get; private set; }
    
    public int GameCount { get; private set; }
}
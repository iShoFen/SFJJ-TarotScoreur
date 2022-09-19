namespace Model;

public class PlayerData
{
    /**
     * References the player who owns the data
     */
    public Player Player { get; internal set; }

    public int WinCount { get; internal set; }

    public int LossCount { get; internal set; }

    public int GameCount { get; internal set; }

    
}
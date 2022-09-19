namespace Model;

public class PlayerRanking : Ranking<PlayerData, Player>
{
    public PlayerRanking(string name, GameType gameType, params PlayerData[] data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<Player> SortByAscendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByAscendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByAscendingLoss()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByAscendingScore()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByAscendingWin()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingLoss()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingScore()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingWin()
    {
        //TODO
        throw new NotImplementedException();
    }
}
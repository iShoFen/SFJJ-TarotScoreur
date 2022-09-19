namespace Model;

public class PlayerRanking : Ranking<Player>
{
    public PlayerRanking(string name, GameType gameType, IEnumerable<Player> data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<Player> SortByAscendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByAscendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDescendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByDateRange(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByWin()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Player> SortByLoss()
    {
        throw new NotImplementedException();
    }
}
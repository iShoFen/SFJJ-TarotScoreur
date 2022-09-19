namespace Model;

public class GameRanking : Ranking<Game>
{
    public GameRanking(string name, GameType gameType, IEnumerable<Game> data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<Game> SortByAscendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByAscendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDateRange(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByWin()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByLoss()
    {
        throw new NotImplementedException();
    }
}
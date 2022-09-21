namespace Model.Ranking;

public class GameRanking : Ranking<Game, Game>
{
    public GameRanking(string name, GameType gameType, params Game[] data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<Game> SortByAscendingDate()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByAscendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByAscendingLoss()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByAscendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByAscendingWin()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingDate()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingLoss()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Game> SortByDescendingWin()
    {
        throw new NotImplementedException();
    }
}
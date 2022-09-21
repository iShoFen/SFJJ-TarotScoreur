namespace Model.Ranking;

public class GameRanking : Ranking<Gaming.Game, Gaming.Game>
{
    public GameRanking(string name, GameType gameType, params Gaming.Game[] data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<Gaming.Game> SortByAscendingDate()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByAscendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByAscendingLoss()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByAscendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByAscendingWin()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByDescendingDate()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByDescendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByDescendingLoss()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByDescendingScore()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<Gaming.Game> SortByDescendingWin()
    {
        throw new NotImplementedException();
    }
}
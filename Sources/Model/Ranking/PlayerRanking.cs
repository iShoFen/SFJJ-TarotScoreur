namespace Model.Ranking;

public class PlayerRanking : Ranking<PlayerData>
{
    public PlayerRanking(string name, GameType gameType, params PlayerData[] data) : base(name, gameType, data)
    {
    }

    public override IEnumerable<PlayerData> SortByAscendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByAscendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByAscendingLoss() =>
        GenericSort((playerData1, playerData2) => playerData1.LossCount - playerData2.LossCount);

    public override IEnumerable<PlayerData> SortByAscendingScore()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByAscendingWin() => GenericSort((playerData1, playerData2) => playerData1.WinCount - playerData2.WinCount);

    public override IEnumerable<PlayerData> SortByDescendingDate()
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByDescendingDateRange(DateTime startDate, DateTime endDate)
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByDescendingLoss() =>
        GenericSort((playerData1, playerData2) => playerData2.LossCount - playerData1.LossCount);

    public override IEnumerable<PlayerData> SortByDescendingScore()
    {
        //TODO
        throw new NotImplementedException();
    }

    public override IEnumerable<PlayerData> SortByDescendingWin() =>
        GenericSort((playerData1, playerData2) => playerData2.WinCount - playerData1.WinCount);
}
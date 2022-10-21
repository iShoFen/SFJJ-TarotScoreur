namespace Model.Sorting;

public static class PlayerRanking
{
    public static IEnumerable<PlayerData> SortByAscendingFirstName(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData1.Player.FirstName, playerData2.Player.FirstName, StringComparison.Ordinal));

    public static IEnumerable<PlayerData> SortByDescendingFirstName(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData2.Player.FirstName, playerData1.Player.FirstName, StringComparison.Ordinal));
    
    public static IEnumerable<PlayerData> SortByAscendingLastName(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData1.Player.LastName, playerData2.Player.LastName, StringComparison.Ordinal));

    public static IEnumerable<PlayerData> SortByDescendingLastName(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData2.Player.LastName, playerData1.Player.LastName, StringComparison.Ordinal));
    
    public static IEnumerable<PlayerData> SortByAscendingNickname(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData1.Player.NickName, playerData2.Player.NickName, StringComparison.Ordinal));

    public static IEnumerable<PlayerData> SortByDescendingNickname(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => string.Compare(playerData2.Player.NickName, playerData1.Player.NickName, StringComparison.Ordinal));

    public static IEnumerable<PlayerData> SortByAscendingWin(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => playerData1.WinCount - playerData2.WinCount);

    public static IEnumerable<PlayerData> SortByDescendingWin(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => playerData2.WinCount - playerData1.WinCount);

    public static IEnumerable<PlayerData> SortByAscendingLoss(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => playerData1.LossCount - playerData2.LossCount);
    
    public static IEnumerable<PlayerData> SortByDescendingLoss(params PlayerData[] data)
         => Sorting.Sort(data, (playerData1, playerData2) => playerData2.LossCount - playerData1.LossCount);
    
    public static IEnumerable<PlayerData> SortByAscendingGameCount(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => playerData1.GameCount - playerData2.GameCount);
    
    public static IEnumerable<PlayerData> SortByDescendingGameCount(params PlayerData[] data)
        => Sorting.Sort(data, (playerData1, playerData2) => playerData2.GameCount - playerData1.GameCount);
}
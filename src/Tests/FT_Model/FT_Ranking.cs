using Model;
using Model.Ranking;

var datas = new List<PlayerData>();
for (int i = 0; i < 10; i++)
{
    var random = new Random();
    var p = new Player("Toto" + i, "Titi" + i, "Tutu" + i, "avatar");
    datas.Add(new PlayerData(p, random.Next(10000), random.Next(10000)));
}

var playerRanking = new PlayerRanking("Toto", GameType.FourPlayers, datas.ToArray());


Console.WriteLine("Sort by ascending loss");
foreach (var player in playerRanking.SortByAscendingLoss())
{
    Console.WriteLine($"{player.LossCount} - {player.Player}");
}

Console.WriteLine("---------------------------");

Console.WriteLine("Sort by descending loss");
foreach (var player in playerRanking.SortByDescendingLoss())
{
    Console.WriteLine($"{player.LossCount} - {player.Player}");
}
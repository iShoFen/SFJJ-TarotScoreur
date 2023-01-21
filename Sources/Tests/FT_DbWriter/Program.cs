using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model.Players;
using Tarot2B2Model;
using TarotDB;

Console.WriteLine("Hello, World!");

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

var options = new DbContextOptionsBuilder<TarotDbContext>()
    .UseSqlite(connection)
    .Options;

var unitOfWork = new UnitOfWork(new TarotDbContext(options));
var writer = new DbWriter(unitOfWork);

var player = new Player("Florent", "Marques", "flomSStaar", "flo.1");
var result = await writer.InsertPlayer(player);

Console.WriteLine(result);
if (result == null)
{
    throw new Exception("Player cannot be inserted");
}

var playerToUpdate = new Player(result.Id, "Samuel", "Sirven", result.NickName, result.Avatar);

var updatedPlayer = await writer.UpdatePlayer(playerToUpdate);

Console.WriteLine(updatedPlayer);

if (updatedPlayer == null)
{
    throw new Exception("Player cannot be updated");
}

var deleted = await writer.DeletePlayer(updatedPlayer.Id);

Console.WriteLine($"is deleted: {deleted}");

var reader = new DbReader(unitOfWork);

var players = await reader.GetPlayers(1, 10);
foreach (var p in players)
{
    Console.WriteLine(p);
}
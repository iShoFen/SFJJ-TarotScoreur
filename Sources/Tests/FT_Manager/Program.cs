using Model;
using Model.Players;
using Tarot2B2Model;
using TarotDB;

// Création du manager
Console.WriteLine("Création du manager");
var unitOfWork = new UnitOfWork(new TarotDbContext());
var manager = new Manager(new DbReader(unitOfWork), new DbWriter(unitOfWork));

// Ajout de joueurs
Console.WriteLine("\nAjout de joueurs");
await manager.SavePlayer(new Player("Florent", "Marques", "Flo", "avatar"));
await manager.SavePlayer(new Player("Samuel", "Sirven", "Sam", "avatar"));
await manager.SavePlayer(new Player("Jordan", "Artzet", "Jo", "avatar"));
await manager.SavePlayer(new Player("Julien", "Theme", "Ju", "avatar"));

await manager.SavePlayer(new Player("Marveille", "Champagne", "Marv", "avatar"));
await manager.SavePlayer(new Player("Fanchon", "Tétrault", "Fan", "avatar"));
await manager.SavePlayer(new Player("Jeanne", "Fecteau", "Jean", "avatar"));
await manager.SavePlayer(new Player("Auda", "Faucher", "Auda", "avatar"));

await manager.SavePlayer(new Player("Lundy", "Marquis", "Lun", "avatar"));
await manager.SavePlayer(new Player("Royce", "Lapresse", "Roy", "avatar"));
await manager.SavePlayer(new Player("Karel", "Lagrange", "Kar", "avatar"));
await manager.SavePlayer(new Player("Pierpont", "Carignan", "Pier", "avatar"));

// Recherche des 100 joueurs de la page 1
Console.WriteLine("\nRecherche des 100 joueurs de la page 1");
var players = (await manager.LoadAllPlayer(1, 100))?.ToArray();
// Affichage des joueurs
Console.WriteLine("\nAffichage des joueurs trouvés");
if (players != null)
{
    foreach (var player in players)
    {
        Console.WriteLine(player);
    }

    Console.WriteLine("\nRecherche des 12 joueurs de la page 1");
}

players = (await manager.LoadAllPlayer(1, 12))?.ToArray();
if (players != null)
{
    for (var i = 0; i < 3; i++)
    {
        var group = new Group($"Un super groupe {i}", players[4 * i], players[4 * i + 1], players[4 * i + 2],
            players[4 * i + 3]);
        Console.WriteLine("Ajout d'un groupe");
        await manager.SaveGroup(group);
    }
}

Console.WriteLine("\nRecherche des 20 groupes de la page 1");
var groups = await manager.LoadAllGroups(1, 20);
if (groups != null)
{
	foreach (var group in groups)
	{
		Console.WriteLine($"{group.Name} ({group.Id})");
		foreach (var player in group.Players)
		{
			Console.WriteLine($"\t{player}");
		}
	}
}
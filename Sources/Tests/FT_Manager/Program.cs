using Model;
using Tarot2B2Model;
using TarotDB;

// Création du manager
Console.WriteLine("Création du manager");
var unitOfWork = new UnitOfWork(new TarotDbContext());
var manager = new Manager(new DbReader(unitOfWork), new DbWriter(unitOfWork));

// Ajout de joueurs
Console.WriteLine("\nAjout de joueurs");
await manager.InsertPlayer("Florent", "Marques", "Flo", "avatar");
await manager.InsertPlayer("Samuel", "Sirven", "Sam", "avatar");
await manager.InsertPlayer("Jordan", "Artzet", "Jo", "avatar");
await manager.InsertPlayer("Julien", "Theme", "Ju", "avatar");

await manager.InsertPlayer("Marveille", "Champagne", "Marv", "avatar");
await manager.InsertPlayer("Fanchon", "Tétrault", "Fan", "avatar");
await manager.InsertPlayer("Jeanne", "Fecteau", "Jean", "avatar");
await manager.InsertPlayer("Auda", "Faucher", "Auda", "avatar");

await manager.InsertPlayer("Lundy", "Marquis", "Lun", "avatar");
await manager.InsertPlayer("Royce", "Lapresse", "Roy", "avatar");
await manager.InsertPlayer("Karel", "Lagrange", "Kar", "avatar");
await manager.InsertPlayer("Pierpont", "Carignan", "Pier", "avatar");

// Recherche des 100 joueurs de la page 1
Console.WriteLine("\nRecherche des 100 joueurs de la page 1");
var players = (await manager.GetPlayers(1, 100)).ToArray();
// Affichage des joueurs
Console.WriteLine("\nAffichage des joueurs trouvés");
foreach (var player in players)
{
    Console.WriteLine(player);
}

Console.WriteLine("\nRecherche des 12 joueurs de la page 1");

players = (await manager.GetPlayers(1, 12)).ToArray();
for (var i = 0; i < 3; i++)
{
    Console.WriteLine("Ajout d'un groupe");
    await manager.InsertGroup($"Un super groupe {i}",
                              players[4 * i],
                              players[4 * i + 1],
                              players[4 * i + 2],
                              players[4 * i + 3]
    );
}

Console.WriteLine("\nRecherche des 20 groupes de la page 1");
var groups = await manager.GetGroups(1, 20);
foreach (var group in groups)
{
    Console.WriteLine($"{group.Name} ({group.Id})");
    foreach (var player in group.Players)
    {
        Console.WriteLine($"\t{player}");
    }
}
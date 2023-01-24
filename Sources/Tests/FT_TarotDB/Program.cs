using Microsoft.EntityFrameworkCore;
using TarotDB;

void PrintGroup(GroupEntity group)
{
    // Affichage du groupe
    Console.WriteLine($"Nom du groupe: {group.Name}");
    foreach (var playerEntity in group.Players)
    {
        Console.WriteLine(
            $"({playerEntity.Id}) {playerEntity.FirstName} {playerEntity.LastName} '{playerEntity.Nickname}'");
    }
}

string GetPlayerString(PlayerEntity playerEntity)
{
    return $"({playerEntity.Id}) {playerEntity.FirstName} {playerEntity.LastName} '{playerEntity.Nickname}";
}

// Clear all the database before executing functional test
await using (var context = new TarotDbContext())
{
    context.Database.EnsureDeleted();
}

var playersEntities = new List<PlayerEntity>();
playersEntities.AddRange(new PlayerEntity[]
    {
        new()
        {
            FirstName = "Florent",
            LastName = "Marques",
            Nickname = "Flo",
            Avatar = "avatar"
        },
        new()
        {
            FirstName = "Samuel",
            LastName = "Sirven",
            Nickname = "Sam",
            Avatar = "avatar"
        },
        new UserEntity()
        {
            FirstName = "Julien",
            LastName = "Theme",
            Nickname = "Ju",
            Avatar = "avatar",
            Email = "email",
            Password = "password"
        },
        new()
        {
            FirstName = "Jordan",
            LastName = "Artzet",
            Nickname = "Jo",
            Avatar = "avatar"
        }
    }
);

// Add players in database
await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();

    Console.WriteLine($"Ajout de {playersEntities.Count} joueurs dans le contexte...");
    context.Players.AddRange(playersEntities);

    var result = await context.SaveChangesAsync();
    Console.WriteLine($"Nombre de joueurs sauvegardés dans la base de données: {result}");

    Console.WriteLine("\n--- Fermeture du contexte ---");
}

// Search players in database
await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();

    Console.WriteLine("Recherche de tous les joueurs possédant 'en' dans leur prénom");
    var selectedPlayers = context.Players
        .Where(e => e.FirstName.Contains("en"))
        .OrderBy(e => e.LastName);

    Console.WriteLine($"Nombre de joueurs trouvés: {selectedPlayers.Count()}");
    Console.WriteLine("Joueurs trouvés:");
    foreach (var player in selectedPlayers)
    {
        Console.WriteLine(GetPlayerString(player));
    }

    Console.WriteLine("\n--- Fermeture du contexte ---");
}

// Création d'un groupe
var groupName = "Les meilleurs joueurs";
await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();

    var playersToAdd = new PlayerEntity[]
    {
        new() { Id = 1UL },
        new() { Id = 2UL },
        new() { Id = 13UL },
        new UserEntity
        {
            FirstName = "Nouvel", LastName = "Utilisateur", Nickname = "NewUser", Avatar = "Avatar",
            Email = "toto@gmail.com", Password = "supermotdepasse"
        }
    };

    // Recherche les liens avec les joueurs existants dans la base
    var playersInDb = new List<PlayerEntity>();
    foreach (var playerToAdd in playersToAdd)
    {
        if (playerToAdd.Id == 0)
        {
            Console.WriteLine(
                $"Ajout du nouveau joueur '{GetPlayerString(playerToAdd)}' dans le groupe");
            playersInDb.Add(playerToAdd);
            continue;
        }

        var playerDb = context.Players.Find(playerToAdd.Id);
        if (playerDb is null)
        {
            Console.WriteLine(
                $"Impossible d'ajouter dans le groupe la correspondance du joueur ayant l'ID '{playerToAdd.Id}'");
        }
        else
        {
            Console.WriteLine(
                $"Ajout de la correspondance du joueur '{GetPlayerString(playerDb)}' ayant l'ID '{playerDb.Id}' dans le groupe");
            playersInDb.Add(playerDb);
        }
    }

    var group = new GroupEntity
    {
        Name = groupName,
        Players = playersInDb
    };

    Console.WriteLine("Sauvegarde du groupe dans le contexte...");
    await context.Groups.AddAsync(group);

    Console.WriteLine("Sauvegarde du groupe dans la base de données...");
    await context.SaveChangesAsync();

    Console.WriteLine("\n--- Fermeture du contexte ---");
}

// Recherche et affichage du groupe
await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();

    // Recherche du groupe récemment ajouté
    var group = await context.Groups
        .Include(g => g.Players)
        .FirstOrDefaultAsync(g => g.Name == groupName);

    if (group is null)
    {
        Console.WriteLine($"Impossible de trouver le groupe avec le nom '{groupName}'");
    }
    else
    {
        PrintGroup(group);

        Console.WriteLine("\nListe des joueurs présents dans la base de données:");
        await context.Players.ForEachAsync(p => Console.WriteLine(GetPlayerString(p)));
    }

    Console.WriteLine("\n--- Fermeture du contexte ---");
}

// Suppression d'un joueur
await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();

    const ulong idToDelete = 2UL;
    var playerToDelete = await context.Players.FindAsync(idToDelete);
    if (playerToDelete is null)
    {
        Console.WriteLine($"Impossible de supprimer le joueur avec l'ID {idToDelete} car il n'existe pas");
    }
    else
    {
        Console.WriteLine(
            $"Suppression du joueur ({playerToDelete.Id}) {playerToDelete.FirstName} {playerToDelete.LastName} '{playerToDelete.Nickname}'");
        context.Players.Remove(playerToDelete);
    }

    await context.SaveChangesAsync();

    Console.WriteLine("\n--- Fermeture du contexte ---");
}

await using (var context = new TarotDbContext())
{
    Console.WriteLine("--- Ouverture du contexte ---\n");
    context.Database.EnsureCreated();
    
    Console.WriteLine("Contenu de la base de données après la suppression d'un joueur\n");

    Console.WriteLine("Liste des joueurs présents dans la base de données:");
    await context.Players.ForEachAsync(p => Console.WriteLine(GetPlayerString(p)));
    
    var group = await context.Groups
        .Include(g => g.Players)
        .FirstOrDefaultAsync(g => g.Name == groupName);

    if (group is null)
    {
        Console.WriteLine($"Impossible de trouver le groupe avec le nom '{groupName}'");
    }
    else
    {
        Console.WriteLine("\nAffichage du groupe qui contenait le joueur récemment supprimé");
        PrintGroup(group);
    }
    
    Console.WriteLine("\n--- Fermeture du contexte ---");
}
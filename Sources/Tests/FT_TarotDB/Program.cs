using Tarot2B2Model;
using TarotDB;

Console.WriteLine("Hello, World!");

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

using var context = new TarotDbContext();
context.Database.EnsureCreated();

context.Players.AddRange(playersEntities);

int result = await context.SaveChangesAsync();

Console.WriteLine(result);

var selectedPlayers = context.Players
    .Where(e => e.FirstName.Contains("e"))
    .OrderBy(e => e.LastName);

Console.WriteLine(selectedPlayers.Count());
foreach (var player in selectedPlayers)
{
    Console.WriteLine(player.ToModel());
}

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
        new()
        {
            FirstName = "Julien",
            LastName = "Theme",
            Nickname = "Ju",
            Avatar = "avatar"
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

using var context = new TarotDBContext();
context.Players.AddRange(playersEntities);

int result = await context.SaveChangesAsync();

Console.WriteLine(result);

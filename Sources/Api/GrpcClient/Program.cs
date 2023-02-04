using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;

using var channel = GrpcChannel.ForAddress("http://localhost:5028");

var userClient = new User.UserClient(channel);

var userReply = await userClient.GetUsersAsync(new Pagination
{
    Page = 2,
    PageSize = 2
});

var users = userReply.Users.ToList();
users.ForEach(u => Console.WriteLine($"User: {u}"));

try
{
    var user = userClient.GetUser(new IdRequest { Id = 1UL });
    Console.WriteLine($"User: {user}");
}
catch (RpcException e)
{
    Console.WriteLine($"Error: {e.Status.Detail}");
}

// var groupReply = await groupClient.GetGroupsAsync(new Pagination
// {
//     Page = 1,
//     PageSize = 10
// });
//
// var groups = groupReply.Groups.ToList();
// groups.ForEach(g => Console.WriteLine($"Group: {g}"));

var gameClient = new Game.GameClient(channel);

var reply1 = await gameClient.GetGameAsync(new IdRequest
{
    Id = 3
});

Console.WriteLine($"Game(3): {reply1}");

try
{
    var reply2 = await gameClient.GetGameAsync(new IdRequest
    {
        Id = 150
    });
    Console.WriteLine($"Game(150): {reply2}");
}
catch (RpcException e)
{
    Console.Error.WriteLine("The game was not found");
    Console.WriteLine(e);
}

var reply3 = await gameClient.DeleteGameAsync(new IdRequest
{
    Id = 4
});

Console.WriteLine($"result of deleting game(4): {reply3.Result}");

var reply4 = await gameClient.DeleteGameAsync(new IdRequest
{
    Id = 4
});

Console.WriteLine($"result of deleting game(4): {reply4.Result}");

var reply5 = await gameClient.InsertGameAsync(new GameInsertRequest
{
    Name = "La partie de folie",
    Rules = "FrenchTarotRules",
    StartDate = Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)),
    Players = { 14, 15 }
});

Console.WriteLine($"Insert game result: {reply5}");

try
{
    var reply6 = await gameClient.InsertGameAsync(new GameInsertRequest
    {
        Name = "La partie de folie",
        Rules = "FrenchTarotRules",
        StartDate = Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)),
        Players = { 14, 150 }
    });

    Console.WriteLine($"Insert game result: {reply6}");
}
catch (RpcException e)
{
    Console.WriteLine(e);
}

var handClient = new Hand.HandClient(channel);

var reply7 = await handClient.GetHandByIdAsync(new IdRequest { Id = 15 });

Console.WriteLine($"Hand result: {reply7}");

var reply8 = await handClient.DeleteHandAsync(new IdRequest { Id = 14 });

Console.WriteLine($"Delete hand with id: {reply8}");

Console.WriteLine("Press any key to continue...");
Console.ReadKey();
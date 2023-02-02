
using Grpc.Net.Client;
using GrpcServiceClient;

using var channel = GrpcChannel.ForAddress("http://localhost:7268");

var userClient = new User.UserClient(channel);

var reply = await userClient.GetUsersAsync(new Pagination
{
    Page = 1,
    PageSize = 10
});

var users = reply.Users.ToList();
users.ForEach(u => Console.WriteLine($"User: {u}"));
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
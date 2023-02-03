using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7268");

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
} catch (RpcException e)
{
    Console.WriteLine($"Error: {e.Status.Detail}");
}

/*var groupClient = new Group.GroupClient(channel);

var groupReply = await groupClient.GetGroupsAsync(new Pagination
{
    Page = 1,
    PageSize = 10
});

var groups = groupReply.Groups.ToList();
groups.ForEach(g => Console.WriteLine($"Group: {g}"));*/

Console.WriteLine("Press any key to continue...");
Console.ReadKey();
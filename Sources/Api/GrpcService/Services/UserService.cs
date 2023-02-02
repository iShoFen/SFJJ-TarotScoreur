using Grpc.Core;
using Model.Data;

namespace GrpcService.Services;

public class UserService : User.UserBase
{
    private readonly IReader _reader;

    public UserService(IReader reader)
    {
        _reader = reader;
    }

    public override Task<UserReply> GetUser(UserIdRequest request, ServerCallContext context)
    {
        return Task.FromResult(new UserReply
        {
            Id = 4
        });
    }

    public override async Task<UsersReply> GetUsers(Pagination request, ServerCallContext context)
    {
        var users = await _reader.GetUsers(request.Page, request.PageSize);

        var userReplies = users.Select(u => new UserReply
        {
            Id = u.Id
        });

        var reply = new UsersReply();
        reply.Users.AddRange(userReplies);
        return await Task.FromResult(reply);
    }
}
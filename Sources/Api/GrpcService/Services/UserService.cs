using Grpc.Core;

namespace GrpcService.Services;

public class UserService : User.UserBase
{
    public override Task<UserReply> GetUser(UserIdRequest request, ServerCallContext context)
    {
        return Task.FromResult(new UserReply());
    }

    public override Task<UsersReply> GetUsers(Pagination request, ServerCallContext context)
    {
        return Task.FromResult(new UsersReply
        {
            Users =
            {
                new UserReply
                {
                    Id = 3
                },
                new UserReply
                {
                    Id = 3
                },
                new UserReply
                {
                    Id = 3
                },
            }
        });
    }
}
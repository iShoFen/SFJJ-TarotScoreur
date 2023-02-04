using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

public class UserServiceV1 : User.UserBase
{
    private readonly Manager _manager;
    private readonly ILogger<UserServiceV1> _logger;

    public UserServiceV1(Manager reader, ILogger<UserServiceV1> logger)
    {
        _manager = reader;
        _logger = logger;

        _logger.LogInformation("UserServiceV1 created");
    }

    public override async Task<UsersReply> GetUsers(Pagination request, ServerCallContext context)
    {
        var users = await _manager.GetUsers(request.Page, request.PageSize);
        _logger.LogInformation("All users from page {Page} and page size {PageSize} loaded",
                               request.Page,
                               request.PageSize
        );

        return users.ToUsersReply();
    }

    public override async Task<UserReply> GetUser(IdRequest request, ServerCallContext context)
    {
        var user = await _manager.GetUserById(request.Id);

        if (user == null)
        {
            _logger.LogWarning("User with id {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User with id {request.Id} not found"));
        }

        _logger.LogInformation("User with id {Id} loaded", request.Id);
        return user.ToUserReply();
    }

    public override async Task<UsersReply> GetUsersByPattern(UserPatternRequest request, ServerCallContext context)
    {
        var users = await _manager.GetUsersByPattern(request.Pattern,
                                                     request.Pagination.Page,
                                                     request.Pagination.PageSize
        );

        _logger.LogInformation("All users with pattern {Pattern} from page {Page} and page size {PageSize} loaded",
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    public override async Task<UsersReply> GetUsersByNickname(UserPatternRequest request, ServerCallContext context)
    {
        var users = await _manager.GetUsersByNickname(request.Pattern,
                                                      request.Pagination.Page,
                                                      request.Pagination.PageSize
        );
        _logger.LogInformation("All users with nickname {Pattern} from page {Page} and page size {PageSize} loaded",
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    public override async Task<UsersReply> GetUsersByFirstNameAndLastName(
        UserPatternRequest request,
        ServerCallContext context
    )
    {
        var users = await _manager.GetUsersByFirstNameAndLastName(request.Pattern,
                                                                  request.Pagination.Page,
                                                                  request.Pagination.PageSize
        );
        _logger.LogInformation(
            "All users with first name and last name {Pattern} from page {Page} and page size {PageSize} loaded",
            request.Pattern,
            request.Pagination.Page,
            request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    public override async Task<UserReply> InsertUser(UserInsertRequest request, ServerCallContext context)
    {
        var user = await _manager.InsertUser(request.FirstName,
                                             request.LastName,
                                             request.Nickname,
                                             request.Avatar,
                                             request.Email,
                                             request.Password
        );
        _logger.LogInformation("User with id {Id} inserted", user.Id);

        return user.ToUserReply();
    }

    public override async Task<UserReply> UpdateUser(UserUpdateRequest request, ServerCallContext context)
    {
        var user = await _manager.UpdateUser(request.ToUser());

        if (user == null)
        {
            _logger.LogWarning("User {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User {request.Id} not found"));
        }
        _logger.LogInformation("User with id {Id} updated", request.Id);
        
        return user.ToUserReply();
    }

    public override async Task<BoolResponse> DeleteUser(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteUser(request.Id);
        
        if (!result)
        {
            _logger.LogWarning("User {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User {request.Id} not found"));
        }

        _logger.LogInformation("User with id {Id} deleted", request.Id);
        return new BoolResponse
        {
            Result = result
        };
    }
}

using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

/// <summary>
/// The user service for gRPC v1
/// </summary>
public class UserServiceV1 : User.UserBase
{
    /// <summary>
    /// The manager for the service
    /// </summary>
    private readonly Manager _manager;
    
    /// <summary>
    /// The logger for the service
    /// </summary>
    private readonly ILogger<UserServiceV1> _logger;

    /// <summary>
    /// The constructor for the service
    /// </summary>
    /// <param name="manager">The manager for the service</param>
    /// <param name="logger">The logger for the service</param>
    public UserServiceV1(Manager manager, ILogger<UserServiceV1> logger)
    {
        _manager = manager;
        _logger = logger;

        _logger.LogInformation("UserServiceV1 created");
    }

    /// <summary>
    /// Get all users with pagination
    /// </summary>
    /// <param name="request">The pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UsersReply with users</returns>
    public override async Task<UsersReply> GetUsers(Pagination request, ServerCallContext context)
    {
        var users = (await _manager.GetUsers(request.Page, request.PageSize)).ToList();
        _logger.LogInformation("{UsersCount} users from page {Page} and page size {PageSize} retrieved",
                               users.Count,
                               request.Page,
                               request.PageSize
        );

        return users.ToUsersReply();
    }

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UserReply with user</returns>
    /// <exception cref="RpcException">If user not found</exception>
    public override async Task<UserReply> GetUser(IdRequest request, ServerCallContext context)
    {
        var user = await _manager.GetUserById(request.Id);

        if (user == null)
        {
            _logger.LogWarning("User with id {Id} not found", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User with id {request.Id} not found"));
        }

        _logger.LogInformation("User with id {Id} retrieved", request.Id);
        return user.ToUserReply();
    }

    /// <summary>
    /// Get users by pattern
    /// </summary>
    /// <param name="request">The pattern and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UsersReply with users</returns>
    public override async Task<UsersReply> GetUsersByPattern(UserPatternRequest request, ServerCallContext context)
    {
        var users = (await _manager.GetUsersByPattern(request.Pattern,
                                                      request.Pagination.Page,
                                                      request.Pagination.PageSize
        )).ToList();

        _logger.LogInformation("{UsersCount} users with pattern {Pattern} from page {Page} and page size {PageSize} retrieved",
                               users.Count,
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    /// <summary>
    /// Get users by nickname
    /// </summary>
    /// <param name="request">The pattern and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UsersReply with users</returns>
    public override async Task<UsersReply> GetUsersByNickname(UserPatternRequest request, ServerCallContext context)
    {
        var users = (await _manager.GetUsersByNickname(request.Pattern,
                                                       request.Pagination.Page,
                                                       request.Pagination.PageSize
        )).ToList();
        _logger.LogInformation("{UsersCount} users with nickname {Pattern} from page {Page} and page size {PageSize} retrieved",
                               users.Count,
                               request.Pattern,
                               request.Pagination.Page,
                               request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    /// <summary>
    /// Get users by first name
    /// </summary>
    /// <param name="request">The pattern and pagination</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UsersReply with users</returns>
    public override async Task<UsersReply> GetUsersByFirstNameAndLastName(
        UserPatternRequest request,
        ServerCallContext context
    )
    {
        var users = (await _manager.GetUsersByFirstNameAndLastName(request.Pattern,
                                                                   request.Pagination.Page,
                                                                   request.Pagination.PageSize
        )).ToList();
        _logger.LogInformation(
            "{UsersCount} users with first name and last name {Pattern} from page {Page} and page size {PageSize} retrieved",
            users.Count,
            request.Pattern,
            request.Pagination.Page,
            request.Pagination.PageSize
        );

        return users.ToUsersReply();
    }

    /// <summary>
    /// Insert user
    /// </summary>
    /// <param name="request">The user to insert with email and password</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UserReply with user</returns>
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

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="request">The user to update</param>
    /// <param name="context">The server call context</param>
    /// <returns>The UserReply with user</returns>
    /// <exception cref="RpcException">If user not found</exception>
    public override async Task<UserReply> UpdateUser(UserUpdateRequest request, ServerCallContext context)
    {
        var user = await _manager.UpdateUser(request.ToUser());

        if (user == null)
        {
            _logger.LogWarning("User {Id} not found, it cannot be updated", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User with id {request.Id} not found, it cannot be updated"));
        }
        _logger.LogInformation("User with id {Id} updated", request.Id);
        
        return user.ToUserReply();
    }

    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="request">The id</param>
    /// <param name="context">The server call context</param>
    /// <returns></returns>
    /// <exception cref="RpcException">If user not found</exception>
    public override async Task<BoolResponse> DeleteUser(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteUser(request.Id);
        
        if (!result)
        {
            _logger.LogWarning("User with {Id} not found, it cannot be deleted", request.Id);
            throw new RpcException(new Status(StatusCode.NotFound, $"User with id {request.Id} not found, it cannot be deleted"));
        }

        _logger.LogInformation("User with id {Id} deleted", request.Id);
        return new BoolResponse
        {
            Result = result
        };
    }
}

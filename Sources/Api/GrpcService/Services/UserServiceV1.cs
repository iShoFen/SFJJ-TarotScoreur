using Grpc.Core;
using GrpcService.Extensions;
using Model;

namespace GrpcService.Services;

public class UserServiceV1 : User.UserBase
{
    private readonly Manager _manager;

    public UserServiceV1(Manager reader)
    {
        _manager = reader;
    }

    public override async Task<UsersReply> GetUsers(Pagination request, ServerCallContext context)
    {
        var users = await _manager.GetUsers(request.Page, request.PageSize);
        
        return users.ToUsersReply();
    }
    
    public override async Task<UserReply> GetUser(IdRequest request, ServerCallContext context)
    {
        var user = await _manager.GetUserById(request.Id);

        if (user == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"User with id {request.Id} not found"));
        }
        
        return user.ToUserReply();
    }
    
    public override async Task<UsersReply> GetUsersByPattern(UserPatternRequest request, ServerCallContext context)
    {
        var users = await _manager.GetUsersByPattern(request.Pattern, request.Pagination.Page, request.Pagination.PageSize);
        
        return users.ToUsersReply();
    }

    public override async Task<UsersReply> GetUsersByNickname(UserPatternRequest request, ServerCallContext context)
    {
        var users = await _manager.GetUsersByNickname(request.Pattern, request.Pagination.Page, request.Pagination.PageSize);
        
        return users.ToUsersReply();
    }

    public override async Task<UsersReply> GetUsersByFirstNameAndLastName(UserPatternRequest request, ServerCallContext context)
    {
        var users = await _manager.GetUsersByFirstNameAndLastName(request.Pattern, request.Pagination.Page, request.Pagination.PageSize);
        
        return users.ToUsersReply();
    }

    public override async Task<UserReply> InsertUser(UserInsertRequest request, ServerCallContext context)
    {
        var user = await _manager.InsertUser(request.FirstName, request.LastName, request.Nickname, request.Avatar, request.Email, request.Password);
        
        return user.ToUserReply();
    }

    public override async Task<UserReply> UpdateUser(UserUpdateRequest request, ServerCallContext context)
    {
        var user = await _manager.UpdateUser(request.ToUser());
        
        if (user == null) throw new RpcException(new Status(StatusCode.NotFound, $"User {request.Id} not found"));

        return user.ToUserReply();
    }

    public override async Task<BoolResponse> DeleteUser(IdRequest request, ServerCallContext context)
    {
        var result = await _manager.DeleteUser(request.Id);
        
        return new BoolResponse {Result = result};
    }
}
using AutoMapper;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model.Players;

namespace GrpcService.Extensions;

internal static class UserExtensions
{
    private static readonly MapperConfiguration Config = new (cfg =>
    {
        cfg.CreateMap<Player, UserReply>().ReverseMap();
        cfg.CreateMap<UserUpdateRequest, Model.Players.User>();
    });

    private static readonly Mapper Mapper = new (Config);
    
    public static UserReply ToUserReply(this Player user) 
        => Mapper.Map<UserReply>(user);

    public static UsersReply ToUsersReply(this IEnumerable<Player> users)
    {
        var usersReply = new UsersReply();
        usersReply.Users.AddRange(users.Select(ToUserReply));
        
        return usersReply;
    }

    public static Model.Players.User ToUser(this UserUpdateRequest userRequest)
        => Mapper.Map<Model.Players.User>(userRequest);
    
    public static Player ToUser(this UserReply userReply)
        => Mapper.Map<Player>(userReply);

    public static IEnumerable<Player> ToUsers(this IEnumerable<UserReply> userReplies)
    {
        var users = new List<Player>();
        users.AddRange(userReplies.Select(ToUser));
        
        return users;
    }
}

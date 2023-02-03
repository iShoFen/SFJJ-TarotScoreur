using System.Collections.ObjectModel;
using AutoMapper;

namespace GrpcService.extensions;

internal static class UserExtension
{
    private static readonly MapperConfiguration Config = new (cfg =>
    {
        cfg.CreateMap<Model.Players.User, UserReply>();
        cfg.CreateMap<UserUpdateRequest, Model.Players.User>();
        cfg.CreateMap<UserReply, Model.Players.User>()
           .ForMember(dest => dest.Email, opt => opt.Ignore())
           .ForMember(dest => dest.Password, opt => opt.Ignore());
    });

    private static readonly Mapper Mapper = new (Config);
    
    public static UserReply ToUserReply(this Model.Players.User user) 
        => Mapper.Map<UserReply>(user);
    
    public static UsersReply ToUsersReply(this IEnumerable<Model.Players.User> users)
    {
        var reply = new UsersReply();
        reply.Users.AddRange(users.Select(u => u.ToUserReply()));
        
        return reply;
    }
    
    public static Model.Players.User ToUser(this UserUpdateRequest userRequest)
        => Mapper.Map<Model.Players.User>(userRequest);
    
    public static Model.Players.User ToUser(this UserReply userReply)
        => Mapper.Map<Model.Players.User>(userReply);
}

using AutoMapper;
using Model.Players;

namespace GrpcService.Extensions;

/// <summary>
/// User extensions for mapping
/// </summary>
internal static class UserExtensions
{
    /// <summary>
    /// Mapper configuration for automapper
    /// </summary>
    private static readonly MapperConfiguration Config = new(cfg =>
        {
            cfg.CreateMap<Player, UserReply>();
            cfg.CreateMap<UserUpdateRequest, Model.Players.User>();
        }
    );

    /// <summary>
    /// Mapper for automapper
    /// </summary>
    private static readonly Mapper Mapper = new(Config);
    
    /// <summary>
    /// Map User to UserReplyDetails
    /// </summary>
    /// <param name="user">The user to map</param>
    /// <param name="groups">The groups of the user</param>
    /// <param name="games">The games of the user</param>
    /// <returns>The UserReplyDetails</returns>
    public static UserReplyDetails ToUserReplyDetails(this Model.Players.User user, IEnumerable<ulong> groups, IEnumerable<ulong> games)
        => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Nickname = user.NickName,
            Avatar = user.Avatar,
            Groups = {groups},
            Games = {games}
        };

    /// <summary>
    /// Map User to UserReply
    /// </summary>
    /// <param name="user">The user to map</param>
    /// <returns>The UserReply</returns>
    public static UserReply ToUserReply(this Player user) => Mapper.Map<UserReply>(user);

    /// <summary>
    /// Map User to UserReply
    /// </summary>
    /// <param name="users">The List of users to map</param>
    /// <returns>The UsersReply</returns>
    public static UsersReply ToUsersReply(this IEnumerable<Player> users)
        => new()
        {
            Users =
            {
                users.Select(ToUserReply)
            }
        };
    

    /// <summary>
    /// Map UserUpdateRequest to User
    /// </summary>
    /// <param name="userRequest">The UserUpdateRequest to map</param>
    /// <returns>The User</returns>
    public static Model.Players.User ToUser(this UserUpdateRequest userRequest)
        => Mapper.Map<Model.Players.User>(userRequest);
}

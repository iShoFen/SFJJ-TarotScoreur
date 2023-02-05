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
    {
        var usersReply = new UsersReply();
        usersReply.Users.AddRange(users.Select(ToUserReply));

        return usersReply;
    }

    /// <summary>
    /// Map UserUpdateRequest to User
    /// </summary>
    /// <param name="userRequest">The UserUpdateRequest to map</param>
    /// <returns>The User</returns>
    public static Model.Players.User ToUser(this UserUpdateRequest userRequest)
        => Mapper.Map<Model.Players.User>(userRequest);
}

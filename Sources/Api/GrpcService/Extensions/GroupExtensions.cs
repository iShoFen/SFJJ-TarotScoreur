using AutoMapper;
using Model.Players;

namespace GrpcService.Extensions;

/// <summary>
/// Group extensions for mapping
/// </summary>
internal static class GroupExtensions
{
    /// <summary>
    /// Mapper configuration for automapper
    /// </summary>
    private static readonly MapperConfiguration Config = new (cfg =>
    {
        cfg.CreateMap<Model.Players.Group, GroupReply>()
           .ForMember(dest => dest.Users, opt 
                          => opt.MapFrom(src => src.Players.ToUsersReply().Users));

        cfg.CreateMap<GroupUpdateRequest, Model.Players.Group>()
           .ConstructUsing(src => new Model.Players.Group(src.Id, src.Name, Array.Empty<Player>()));
    });

    /// <summary>
    /// Mapper for automapper
    /// </summary>
    private static readonly Mapper Mapper = new (Config);
    
    /// <summary>
    /// Map Group to Id
    /// </summary>
    /// <param name="groups">The List of groups to map</param>
    /// <returns>The List of Ids</returns>
    public static IEnumerable<ulong> ToIds(this IEnumerable<Model.Players.Group> groups)
        => groups.Select(group => group.Id);

    /// <summary>
    /// Map Group to GroupReply
    /// </summary>
    /// <param name="group">The group to map</param>
    /// <returns>The GroupReply</returns>
    public static GroupReply ToGroupReply(this Model.Players.Group group) 
        => Mapper.Map<GroupReply>(group);

    /// <summary>
    /// Map Group to GroupReply
    /// </summary>
    /// <param name="groups">The List of groups to map</param>
    /// <returns>The GroupsReply</returns>
    public static GroupsReply ToGroupsReply(this IEnumerable<Model.Players.Group> groups)
          => new()
            {
                Groups =
                {
                    groups.Select(ToGroupReply)
                }
            };
    
    /// <summary>
    /// Map GroupUpdateRequest to Group
    /// </summary>
    /// <param name="groupRequest">The GroupUpdateRequest to map</param>
    /// <returns>The Group</returns>
    public static Model.Players.Group ToGroup(this GroupUpdateRequest groupRequest)
        => Mapper.Map<Model.Players.Group>(groupRequest);
}

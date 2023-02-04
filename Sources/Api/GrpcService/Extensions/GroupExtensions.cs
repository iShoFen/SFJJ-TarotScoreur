using AutoMapper;
using Model.Players;

namespace GrpcService.Extensions;

public static class GroupExtensions
{
    private static readonly MapperConfiguration Config = new (cfg =>
    {
        cfg.CreateMap<Model.Players.Group, GroupReply>()
           .ForMember(dest => dest.Players, opt 
                          => opt.MapFrom(src => src.Players.ToUsersReply().Users));
        cfg.CreateMap<GroupReply, Model.Players.Group>()
           .ForMember(dest => dest.Players, opt 
                          => opt.MapFrom(src => src.Players.ToUsers()));
        cfg.CreateMap<GroupUpdateRequest, Model.Players.Group>()
           .ForMember(dest => dest.Players, opt 
                          => opt.MapFrom(src => Array.Empty<Player>()));
    });

    private static readonly Mapper Mapper = new (Config);
    
    public static GroupReply ToGroupReply(this Model.Players.Group group) 
        => Mapper.Map<GroupReply>(group);

    public static GroupsReply ToGroupsReply(this IEnumerable<Model.Players.Group> groups)
    {
        var groupsReply = new GroupsReply();
        groupsReply.Groups.AddRange(groups.Select(ToGroupReply));
        
        return groupsReply;
    }
    
    public static Model.Players.Group ToGroup(this GroupReply groupRequest)
        => Mapper.Map<Model.Players.Group>(groupRequest);
    
    
    public static Model.Players.Group ToGroup(this GroupUpdateRequest groupRequest)
        => Mapper.Map<Model.Players.Group>(groupRequest);
    
}

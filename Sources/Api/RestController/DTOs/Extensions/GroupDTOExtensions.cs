using AutoMapper;
using Model.Players;
using RestController.DTOs.Games;

namespace RestController.DTOs.Extensions;

internal static class GroupDTOExtensions
{
    private  static readonly MapperConfiguration MapperConfig = 
        new(cfg =>
        cfg.CreateMap<Group, GroupDTO>()
            .ForMember(dest => dest.Users, act => act.MapFrom(src => src.Players.Select(p => p.Id)))
        );
    private static readonly Mapper Mapper = new(MapperConfig);

    public static GroupDTO ToGroupDTO(this Group group) => Mapper.Map<Group, GroupDTO>(group);

    public static Group ToGroup(this GroupDTO groupDTO) => Mapper.Map<GroupDTO, Group>(groupDTO);
}



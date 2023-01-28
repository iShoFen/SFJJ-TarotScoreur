using System;
using AutoMapper;
using Model.Players;

namespace RestController.DTOs.Extensions;

internal static class GroupDTOExtensions
{
    private static MapperConfiguration _mapperConfig;
    private static Mapper _mapper;

    static GroupDTOExtensions()
    {
        _mapperConfig = new MapperConfiguration(cfg =>
            cfg.CreateMap<Group, GroupDTO>()
            .ForMember(dest => dest.Users, act => act.MapFrom(src => src.Players.Select(p => p.Id))).ReverseMap()
        ); 
        _mapper = new Mapper(_mapperConfig);
    }

    public static GroupDTO ToGroupDTO(this Group group) => _mapper.Map<Group, GroupDTO>(group);

    public static Group ToGroup(this GroupDTO groupDTO) => _mapper.Map<GroupDTO, Group>(groupDTO);
}



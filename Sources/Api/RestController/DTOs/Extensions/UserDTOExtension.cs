using System;
using AutoMapper;
using Model.Players;

namespace RestController.DTOs.Extensions;

internal static class UserDTOExtensions
{
    private static MapperConfiguration _mapperConfig;
    private static Mapper _mapper;

    static UserDTOExtensions()
    {
        _mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<UserDTOPostRequest, User>();
        });
        _mapper = new Mapper(_mapperConfig);
    }

    public static UserDTO UserToDTO(this User user) => _mapper.Map<User, UserDTO>(user);

    public static User UserDTOPostRequestToUser(this UserDTOPostRequest userDtoPostRequest) =>
        _mapper.Map<UserDTOPostRequest, User>(userDtoPostRequest);

    public static User DTOToUser(this UserDTO userDto) => _mapper.Map<UserDTO, User>(userDto);

    public static UserDTO PlayerToDTO(this Player player) =>
        new()
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Nickname = player.NickName,
            Avatar = player.Avatar
        };

    public static Player DTOToPlayer(this UserDTO userDTO) =>
        new Player(
            userDTO.Id,
            userDTO.FirstName,
            userDTO.LastName,
            userDTO.Nickname,
            userDTO.Avatar
            );
}



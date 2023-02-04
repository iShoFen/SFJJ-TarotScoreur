using System;
using AutoMapper;
using Model.Players;

namespace RestController.DTOs.Extensions;

internal static class UserDTOExtensions
{
    private static readonly MapperConfiguration MapperConfig = 
        new(cfg =>
        {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<UserDTOPostRequest, User>().ReverseMap();
        });
    private static readonly Mapper Mapper = new (MapperConfig);

    public static UserDTO UserToDTO(this User user) => Mapper.Map<User, UserDTO>(user);

    public static User UserDTOPostRequestToUser(this UserDTOPostRequest userDtoPostRequest) =>
        Mapper.Map<UserDTOPostRequest, User>(userDtoPostRequest);

    public static User DTOToUser(this UserDTO userDto) => Mapper.Map<UserDTO, User>(userDto);

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



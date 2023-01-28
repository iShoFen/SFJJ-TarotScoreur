using System;
using AutoMapper;
using Model.Players;

namespace RestController.DTOs.Extensions;

internal static class UserDTOExtensions
{
    //private static MapperConfiguration _mapperConfig;
    //private static Mapper _mapper;

    public static UserDTO UserToDTO(this User user) =>
            new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Nickname = user.NickName,
                Avatar = user.Avatar,
                Email = user.Email
            };

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



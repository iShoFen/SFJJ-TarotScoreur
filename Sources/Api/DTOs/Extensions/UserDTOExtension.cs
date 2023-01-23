using System;
using Model.Players;

namespace DTOs.Extensions
{
	internal static class UserDTOExtensions
	{
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
}


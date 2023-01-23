using System;
using Model.Players;

namespace DTOs.Extensions
{
	internal static class GroupDTOExtensions
	{

		public static GroupDTO GroupToDTO(this Group group) =>
			new()
			{
				Id = group.Id,
				Name = group.Name,
				Users = group.Players.Select(x => x.PlayerToDTO()).ToList()
			};

		public static Group GroupDTOTOGroup(this GroupDTO groupDTO) =>
			new Group(
				groupDTO.Name,
				(Player) groupDTO.Users);
	}
}



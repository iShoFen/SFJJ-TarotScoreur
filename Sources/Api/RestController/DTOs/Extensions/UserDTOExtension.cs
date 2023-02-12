using AutoMapper;
using Model.Players;
using RestController.DTOs.Games;

namespace RestController.DTOs.Extensions;

internal static class UserDTOExtensions
{
    private static readonly MapperConfiguration MapperConfig =
        new(cfg =>
        {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<UserInsertRequest, User>().ReverseMap();
            cfg.CreateMap<User, UserDetailDTO>().ReverseMap();
        });

    private static readonly Mapper Mapper = new(MapperConfig);

    public static UserDTO UserToDTO(this User user) => Mapper.Map<User, UserDTO>(user);

    public static UserDTO PlayerToDTO(this Player player) => new()
    {
        Id = player.Id,
        FirstName = player.FirstName,
        LastName = player.LastName,
        Nickname = player.NickName,
        Avatar = player.Avatar
    };
    
    public static UserDetailDTO UserToUserDetailDTO(this User user) => Mapper.Map<User, UserDetailDTO>(user);
}
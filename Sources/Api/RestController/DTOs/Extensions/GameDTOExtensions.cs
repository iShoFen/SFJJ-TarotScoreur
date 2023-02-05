using AutoMapper;
using Model.Games;
using RestController.DTOs.games;

namespace RestController.DTOs.Extensions;

internal static class GameDTOExtensions
{
    private static readonly MapperConfiguration MapperConfiguration = 
        new(config =>
        {
            config.CreateMap<Game, GameDTO>().ReverseMap();
            config.CreateMap<Game, GameDetailDTO>()
            .ForMember(dest => dest.Users, act => 
                act.MapFrom(src => src.Players.Select(p => p.Id)))
            .ForMember(dest => dest.Hands, act => 
                act.MapFrom(src => src.Hands.Select(kvp => kvp.Value.Id)))
            .ForMember(dest => dest.Rules, act =>
                act.MapFrom(src => src.Rules.Name))
            .ReverseMap();
        });
    private static readonly Mapper Mapper =new(MapperConfiguration);

    public static GameDTO ToGameDTO(this Game game) => Mapper.Map<Game, GameDTO>(game);
    public static GameDetailDTO ToGameDetailDTO(this Game game) => Mapper.Map<Game, GameDetailDTO>(game);

    public static Game ToGameModel(this GameDetailDTO gameDetailDto) => Mapper.Map<GameDetailDTO, Game>(gameDetailDto);
}

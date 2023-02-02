using AutoMapper;
using Model.Games;

namespace RestController.DTOs.Extensions;

internal static class GameDTOExtensions
{
    private static MapperConfiguration _mapperConfiguration;
    private static Mapper _mapper;

    static GameDTOExtensions()
    {
        _mapperConfiguration = new MapperConfiguration(config =>
            config.CreateMap<Game, GameDTO>()
                .ForMember(dest => dest.Users, act => act.MapFrom(src => src.Players.Select(p => p.Id))).ReverseMap()

        );
        _mapper = new Mapper(_mapperConfiguration);
    }

    public static GameDTO ToGameDTO(this Game game) => _mapper.Map<Game, GameDTO>(game);

    public static Game ToGameModel(this GameDTO gameDto) => _mapper.Map<GameDTO, Game>(gameDto);
}

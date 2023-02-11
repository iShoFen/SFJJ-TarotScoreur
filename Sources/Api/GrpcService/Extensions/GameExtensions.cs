using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Model.Rules;

namespace GrpcService.Extensions;

/// <summary>
/// Game extensions for mapping
/// </summary>
internal static class GameExtensions
{
    /// <summary>
    /// Mapper configuration for automapper
    /// </summary>
    private static readonly MapperConfiguration Config = new(cfg =>
        {
            cfg.CreateMap<IRules, string>()
               .ConvertUsing(src => src.Name);

            cfg.CreateMap<DateTime?, Timestamp?>()
               .ConvertUsing(src => src.HasValue ? Timestamp.FromDateTime(DateTime.SpecifyKind(src.Value, DateTimeKind.Utc)) : null);
            
            cfg.CreateMap<DateTime, Timestamp>()
               .ConvertUsing(src => Timestamp.FromDateTime(DateTime.SpecifyKind(src, DateTimeKind.Utc)));

            cfg.CreateMap<Model.Games.Game, GameReply>();
            cfg.CreateMap<Model.Games.Game, GameReplyDetails>()
               .ForMember(dest => dest.Players,
                          opt =>
                              opt.MapFrom(g => g.Players.Select(p => p.Id))
               )
               .ForMember(dest => dest.Hands,
                          opt =>
                              opt.MapFrom(g => g.Hands.Select(kvp => kvp.Value.Id))
               )
               .ForMember(dest => dest.Rules,
                          opt =>
                              opt.MapFrom(src => src.Rules.Name)
               );
        }
    );

    /// <summary>
    /// Mapper for automapper
    /// </summary>
    private static readonly Mapper Mapper = new(Config);
    
    /// <summary>
    /// Map Game to Id
    /// </summary>
    /// <param name="games">The List of games to map</param>
    /// <returns>The List of Ids</returns>
    public static IEnumerable<ulong> ToIds(this IEnumerable<Model.Games.Game> games)
        => games.Select(p => p.Id);

    /// <summary>
    /// Map Game to GameReplyDetails
    /// </summary>
    /// <param name="game">The game to map</param>
    /// <returns>The GameReplyDetails</returns>
    public static GameReplyDetails ToGameReplyDetails(this Model.Games.Game game) 
        => Mapper.Map<GameReplyDetails>(game);

    /// <summary>
    /// Map Game to GameReply
    /// </summary>
    /// <param name="games">The List of games to map</param>
    /// <returns>The GamesReply</returns>
    public static GamesReply ToGamesReply(this IEnumerable<Model.Games.Game> games)
        => new()
        {
            Games =
            {
                games.Select(Mapper.Map<GameReply>)
            }
        };

    /// <summary>
    /// Map GameReplyDetails to Game
    /// </summary>
    /// <param name="reply">The GameReply to map</param>
    /// <returns>The Game</returns>
    public static Model.Games.Game? ToGame(this GameReplyDetails reply)
    {
        var rules = RulesFactory.Create(reply.Rules);
        if (rules is null) return null;

        DateTime? endDate = reply.EndDate != null ? reply.EndDate.ToDateTime() : null;

        var game = new Model.Games.Game(reply.Id, reply.Name, rules, reply.StartDate.ToDateTime(), endDate);

        return game;
    }
}

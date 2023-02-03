using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Model.Rules;

namespace GrpcService.extensions;

internal static class GameExtensions
{
    private static readonly MapperConfiguration Config = new(cfg =>
    {
        // For Game to GameReply
        cfg.CreateMap<Model.Games.Game, GameReply>()
            .ForMember(dest => dest.StartDate, opt =>
                opt.MapFrom(g => Timestamp.FromDateTime(DateTime.SpecifyKind(g.StartDate, DateTimeKind.Utc))))
            .ForMember(dest => dest.Players, opt =>
                opt.MapFrom(g => g.Players.Select(p => p.Id)))
            .ForMember(dest => dest.Hands, opt =>
                opt.MapFrom(g => g.Hands.Select(kvp => kvp.Value.Id)))
            .ReverseMap();
        // For DateTime? to Timestamp?
        cfg.CreateMap<DateTime?, Timestamp?>()
            .ConvertUsing(src => src.HasValue ? Timestamp.FromDateTime(src.Value) : null);
        cfg.CreateMap<Timestamp?, DateTime?>()
            .ConvertUsing(src => src != null ? src.ToDateTime() : null);
    });

    private static readonly Mapper Mapper = new(Config);

    public static GameReply ToGameReply(this Model.Games.Game game)
        => Mapper.Map<GameReply>(game);

    public static GamesReply ToGamesReply(this IEnumerable<Model.Games.Game> games)
    {
        var reply = new GamesReply();
        reply.Games.AddRange(games.Select(g => g.ToGameReply()));
        return reply;
    }

    public static Model.Games.Game? ToGame(this GameReply reply)
    {
        var rules = RulesFactory.Create(reply.Rules);
        if (rules is null) return null;

        DateTime? endDate = reply.EndDate != null ? reply.EndDate.ToDateTime() : null;

        var game = new Model.Games.Game(reply.Id, reply.Name, rules, reply.StartDate.ToDateTime(), endDate);

        return game;
    }
}
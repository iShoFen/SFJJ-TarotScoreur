using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Model.Enums;
using Model.Players;

namespace GrpcService.Extensions;

internal static class HandExtensions
{
    private static readonly MapperConfiguration Config = new(cfg =>
    {
        cfg.CreateMap<Model.Games.Hand, HandReply>()
            .ForMember(dest => dest.Rules, opt =>
                opt.MapFrom(src => src.Rules.Name))
            .ForMember(dest => dest.Petit, opt =>
                opt.MapFrom(src => src.Petit))
            .ForMember(dest => dest.Chelem, opt =>
                opt.MapFrom(src => src.Chelem))
            .ForMember(dest => dest.Date, opt =>
                opt.MapFrom(g => Timestamp.FromDateTime(DateTime.SpecifyKind(g.Date, DateTimeKind.Utc))))
            .ReverseMap();
        cfg.CreateMap<KeyValuePair<Player, (Biddings, Poignee)>, UserBiddingPoignee>()
            .ForMember(dest => dest.PlayerId, opt =>
                opt.MapFrom(src => src.Key.Id))
            .ForMember(dest => dest.Bidding, opt =>
                opt.MapFrom(kvp => kvp.Value.Item1))
            .ForMember(dest => dest.Poignee, opt =>
                opt.MapFrom(kvp => kvp.Value.Item2));
        ;
    });

    private static readonly Mapper Mapper = new(Config);

    public static HandReply ToHandReply(this Model.Games.Hand hand)
        => Mapper.Map<HandReply>(hand);

    public static Chelem ToModel(this CHELEM chelem)
        => Mapper.Map<Chelem>(chelem);

    public static PetitResults ToModel(this PETIT_RESULT petit)
        => Mapper.Map<PetitResults>(petit);

    public static Biddings ToModel(this BIDDING bidding)
        => Mapper.Map<Biddings>(bidding);

    public static Poignee ToModel(this POIGNEE poignee)
        => Mapper.Map<Poignee>(poignee);
}
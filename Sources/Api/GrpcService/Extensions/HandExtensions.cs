using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Model.Enums;
using Model.Players;

namespace GrpcService.Extensions;

/// <summary>
/// Hand extensions for mapping
/// </summary>
internal static class HandExtensions
{
    /// <summary>
    /// Mapper configuration for automapper
    /// </summary>
    private static readonly MapperConfiguration Config = new(cfg =>
    {
        cfg.CreateMap<Model.Games.Hand, HandReply>()
           .ForMember(dest => dest.Rules,
                      opt =>
                          opt.MapFrom(src => src.Rules.Name)
           )
           .ForMember(dest => dest.Petit,
                      opt =>
                          opt.MapFrom(src => src.Petit)
           )
           .ForMember(dest => dest.Chelem,
                      opt =>
                          opt.MapFrom(src => src.Chelem)
           )
           .ForMember(dest => dest.Date,
                      opt =>
                          opt.MapFrom(g => Timestamp.FromDateTime(DateTime.SpecifyKind(g.Date, DateTimeKind.Utc)))
           );

        cfg.CreateMap<KeyValuePair<Player, (Biddings, Poignee)>, UserBiddingPoignee>()
           .ForMember(dest => dest.PlayerId,
                      opt =>
                          opt.MapFrom(src => src.Key.Id)
           )
           .ForMember(dest => dest.Bidding,
                      opt =>
                          opt.MapFrom(kvp => kvp.Value.Item1)
           )
           .ForMember(dest => dest.Poignee,
                      opt =>
                          opt.MapFrom(kvp => kvp.Value.Item2)
           );
    });

    /// <summary>
    /// Mapper for automapper
    /// </summary>
    private static readonly Mapper Mapper = new(Config);

    /// <summary>
    /// Map Hand to HandReply
    /// </summary>
    /// <param name="hand">The hand to map</param>
    /// <returns>The HandReply</returns>
    public static HandReply ToHandReply(this Model.Games.Hand hand)
        => Mapper.Map<HandReply>(hand);

    /// <summary>
    /// Map CHELEM to Chelem
    /// </summary>
    /// <param name="chelem">The CHELEM to map</param>
    /// <returns>The Chelem</returns>
    public static Chelem ToModel(this CHELEM chelem)
        => Mapper.Map<Chelem>(chelem);

    /// <summary>
    /// Map PETIT_RESULT to PetitResults
    /// </summary>
    /// <param name="petit">The PETIT_RESULT to map</param>
    /// <returns>The PetitResults</returns>
    public static PetitResults ToModel(this PETIT_RESULT petit)
        => Mapper.Map<PetitResults>(petit);

    /// <summary>
    /// Map BIDDING to Biddings
    /// </summary>
    /// <param name="bidding">The BIDDING to map</param>
    /// <returns>The Biddings</returns>
    public static Biddings ToModel(this BIDDING bidding)
        => Mapper.Map<Biddings>(bidding);

    /// <summary>
    /// Map POIGNEE to Poignee
    /// </summary>
    /// <param name="poignee">The POIGNEE to map</param>
    /// <returns>The Poignee</returns>
    public static Poignee ToModel(this POIGNEE poignee)
        => Mapper.Map<Poignee>(poignee);
}
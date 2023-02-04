using AutoMapper;
using Model.Enums;
using Model.Players;

namespace RestController.DTOs.Extensions
{
    internal static class BiddingsPoigneeDTOExtensions
    {
        private static readonly MapperConfiguration MapperConfigutation = 
            new(cfg =>
            {
                cfg.CreateMap<KeyValuePair<Player, (Biddings, Poignee)>, BiddingPoigneeDTO>()
                    .ForMember(dest => dest.Biddings, act 
                        => act.MapFrom(src => src.Value.Item1.ToBiddingsDTO()))
                        
                    .ForMember(dest => dest.Poignee, act 
                        => act.MapFrom(src => src.Value.Item2.ToPoigneeDTO()))
                        
                    .ForMember(dest => dest.UserId, act 
                        => act.MapFrom(src => src.Key.Id));
            });
        private static readonly Mapper Mapper = new(MapperConfigutation);

        public static BiddingPoigneeDTO ToBiddingPoigneeDTO(this KeyValuePair<Player, (Biddings, Poignee)> bidding)
            => Mapper.Map<BiddingPoigneeDTO>(bidding);
    }
}
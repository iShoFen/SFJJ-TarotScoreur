using System.Collections;
using System.Collections.ObjectModel;
using AutoMapper;
using Model.Enums;
using Model.Players;

namespace RestController.DTOs.Extensions
{
    internal static class BiddingsPoigneeDTOExtensions
    {
        private static MapperConfiguration _mapperConfigutation;
        private static Mapper _mapper;

        static BiddingsPoigneeDTOExtensions()
        {
            _mapperConfigutation = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<KeyValuePair<Player, (Biddings, Poignee)>, BiddingPoigneeDTO>()
                    .ForMember(dest => dest.Biddings, act =>
                        act.MapFrom(src => src.Value.Item1.ToBiddingsDTO()))
                    .ForMember(dest => dest.Poignee,
                        act => act.MapFrom(src => src.Value.Item2.ToPoigneeDTO()))
                    .ForMember(dest => dest.UserId, act => 
                        act.MapFrom(src => src.Key.Id));
            });
            _mapper = new Mapper(_mapperConfigutation);
        }

        public static BiddingPoigneeDTO ToBiddingPoigneeDTO(this KeyValuePair<Player, (Biddings, Poignee)> kvp)
            => _mapper.Map<BiddingPoigneeDTO>(kvp);
    }
}
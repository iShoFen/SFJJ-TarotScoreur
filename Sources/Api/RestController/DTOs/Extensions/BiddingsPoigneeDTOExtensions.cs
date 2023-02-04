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
				cfg.CreateMap<IReadOnlyDictionary<Player, (Biddings, Poignee)>, BiddingPoigneeDTO>()
				.ForMember(dest => dest.Biddings, act => act.MapFrom(src => src.Select(x => x.Value.Item1.ToBiddingsDTO())))
				.ForMember(dest => dest.Poignee, act => act.MapFrom(src => src.Select(x => x.Value.Item2.ToPoigneeDTO())))
				.ForMember(dest => dest.UserId, act => act.MapFrom(src => src.Select(x => x.Key.Id)));
			});
			_mapper = new Mapper(_mapperConfigutation);
		}

		public static BiddingPoigneeDTO ToBiddingPoigneeDTO(this ReadOnlyDictionary<Player, (Biddings, Poignee)> biddings) => _mapper.Map<ReadOnlyDictionary<Player, (Biddings, Poignee)>, BiddingPoigneeDTO>(biddings);
	}
}


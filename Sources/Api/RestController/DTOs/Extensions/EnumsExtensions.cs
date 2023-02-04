using System;
using AutoMapper;
using Model.Enums;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
{
	internal static class EnumsExtensions
	{
		private static readonly MapperConfiguration MapperConfig = new (cfg =>
		{
			cfg.CreateMap<Biddings, BiddingsDTO>();
			cfg.CreateMap<Poignee, PoigneeDTO>();
		});
		private static readonly Mapper Mapper = new (MapperConfig);

		public static BiddingsDTO ToBiddingsDTO(this Biddings biddings) => Mapper.Map<Biddings, BiddingsDTO>(biddings);

		public static PoigneeDTO ToPoigneeDTO(this Poignee poignee) => Mapper.Map<Poignee, PoigneeDTO>(poignee);
	}
}


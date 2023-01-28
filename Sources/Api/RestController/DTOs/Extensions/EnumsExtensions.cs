using System;
using AutoMapper;
using Model.Enums;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
{
	internal static class EnumsExtensions
	{
		private static MapperConfiguration _mapperConfig;
		private static Mapper _mapper;

		static EnumsExtensions()
		{
			_mapperConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Biddings, BiddingsDTO>();
				cfg.CreateMap<Poignee, PoigneeDTO>();
			});
			_mapper = new Mapper(_mapperConfig);
		}

		public static BiddingsDTO ToBiddingsDTO(this Biddings biddings) => _mapper.Map<Biddings, BiddingsDTO>(biddings);

		public static PoigneeDTO ToPoigneeDTO(this Poignee poignee) => _mapper.Map<Poignee, PoigneeDTO>(poignee);
	}
}


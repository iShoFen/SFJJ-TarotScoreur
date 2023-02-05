using AutoMapper;
using Model.Enums;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
{
	internal static class EnumsExtensions
	{
		private static readonly MapperConfiguration MapperConfig = new (cfg =>
		{
			cfg.CreateMap<Biddings, BiddingsDTO>().ReverseMap();
			cfg.CreateMap<Poignee, PoigneeDTO>().ReverseMap();
		});
		private static readonly Mapper Mapper = new (MapperConfig);

		public static BiddingsDTO ToBiddingsDTO(this Biddings biddings) => Mapper.Map<Biddings, BiddingsDTO>(biddings);

		public static PoigneeDTO ToPoigneeDTO(this Poignee poignee) => Mapper.Map<Poignee, PoigneeDTO>(poignee);

		public static Biddings ToBiddings(this BiddingsDTO biddingsDto)
			=> Mapper.Map<Biddings>(biddingsDto);
		
		public static Poignee ToPoignee(this PoigneeDTO poigneeDto)
			=> Mapper.Map<Poignee>(poigneeDto);
	}
}


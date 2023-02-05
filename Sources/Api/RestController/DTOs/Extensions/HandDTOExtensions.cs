using AutoMapper;
using Model.Games;
using RestController.DTOs.Games;

namespace RestController.DTOs.Extensions
{
    public static class HandDTOExtensions
    {
        private static readonly MapperConfiguration MapperConfig =
            new(cfg =>
            {
                cfg.CreateMap<Hand, HandDTODetail>()
                    .ForMember(h => h.Petit, opt
                        => opt.MapFrom(h => h.Petit.ToPetitResultsDTO()))
                    .ForMember(h => h.Chelem, opt
                        => opt.MapFrom(h => h.Chelem.ToChelemDTO()))
                    .ForMember(h => h.Biddings, opt
                        => opt.MapFrom(h => h.Biddings.Select(b
                            => b.ToBiddingPoigneeDTO())))
                    .ForMember(dest => dest.Rules, opt =>
                        opt.MapFrom(src => src.Rules.Name));

                cfg.CreateMap<HandDTODetail, Hand>()
                    .ForMember(h => h.Petit, opt
                        => opt.MapFrom(h => h.Petit.ToPetitResults()))
                    .ForMember(h => h.Chelem, opt
                        => opt.MapFrom(h => h.Chelem.ToChelem()));
            });

        private static readonly Mapper Mapper = new(MapperConfig);

        /// <summary>
        /// This method maps a Hand to a HandDTODetail
        /// </summary>
        /// <param name="hand">The hand to map</param>
        /// <returns>The mapped HandDTODetail</returns>
        public static HandDTODetail ToHandDTODetail(this Hand hand) => Mapper.Map<Hand, HandDTODetail>(hand);

        /// <summary>
        /// Ths method maps a HandDTO to a Hand
        /// </summary>
        /// <param name="handDtoDetail">The handDTO to map</param>
        /// <returns>The mapped hand</returns>
        public static Hand ToHand(this HandDTODetail handDtoDetail) => Mapper.Map<HandDTODetail, Hand>(handDtoDetail);
    }
}
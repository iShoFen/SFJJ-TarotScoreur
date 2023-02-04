using Model.Games;using System;
using AutoMapper;

namespace RestController.DTOs.Extensions
{
    public static class HandDTOExtensions
    {
        private static readonly MapperConfiguration _mapperConfig;
        private static readonly Mapper _mapper;
       
        /// <summary>
        /// Constructor for the HandDTOExtensions class
        /// </summary>
        static HandDTOExtensions()
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hand, HandDTODetail>()
                    .ForMember(h => h.Petit, opt 
                        => opt.MapFrom(h => h.Petit.ToPetitResultsDTO()))
                    
                    .ForMember(h => h.Chelem, opt 
                        => opt.MapFrom(h => h.Chelem.ToChelemDTO()))
                    
                    .ForMember(h => h.Biddings, opt 
                        => opt.MapFrom(h => h.Biddings.Select(b 
                            => b.ToBiddingPoigneeDTO())));
                
                cfg.CreateMap<HandDTODetail, Hand>()
                    .ForMember(h => h.Petit, opt 
                        => opt.MapFrom(h => h.Petit.ToPetitResults()))
                    
                    .ForMember(h => h.Chelem, opt 
                        => opt.MapFrom(h => h.Chelem.ToChelem()));
            });
            _mapper = new Mapper(_mapperConfig);
        }

        /// <summary>
        /// This method maps a Hand to a HandDTODetail
        /// </summary>
        /// <param name="hand">The hand to map</param>
        /// <returns>The mapped HandDTODetail</returns>
        public static HandDTODetail ToHandDTODetail(this Hand hand) => _mapper.Map<Hand, HandDTODetail>(hand);

        /// <summary>
        /// Ths method maps a HandDTO to a Hand
        /// </summary>
        /// <param name="handDtoDetail">The handDTO to map</param>
        /// <returns>The mapped hand</returns>
        public static Hand ToHand(this HandDTODetail handDtoDetail) => _mapper.Map<HandDTODetail, Hand>(handDtoDetail);

    }
}
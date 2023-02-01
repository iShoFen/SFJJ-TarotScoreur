using Model.Games;
using AutoMapper;
using System;
using DTOs.Enums;
using Model.Enums;

namespace DTOs.Extensions
{
    public static class HandDTOExtensions
    {
        private static MapperConfiguration _mapperConfig;
        private static Mapper _mapper;
       
        /// <summary>
        /// Constructor for the HandDTOExtensions class
        /// </summary>
        static HandDTOExtensions()
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hand, HandDTO>()
                    .ForMember(h => h.Petit, opt => opt.MapFrom(h => h.Petit.ToPetitResultsDTO()));
                cfg.CreateMap<HandDTO, Hand>()
                    .ForMember(h => h.Petit, opt => opt.MapFrom(h => h.Petit.ToPetitResults()));
            });
            _mapper = new Mapper(_mapperConfig);
        }

        /// <summary>
        /// This method maps a HandDTO to a Hand
        /// </summary>
        /// <param name="hand">The hand to map</param>
        /// <returns>The mapped hand</returns>
        public static HandDTO ToHandDTO(this Hand hand) => _mapper.Map<Hand, HandDTO>(hand);
        
        /// <summary>
        /// Ths method maps a Hand to a HandDTO
        /// </summary>
        /// <param name="handDTO">The handDTO to map</param>
        /// <returns>The mapped handDTO</returns>
        public static Hand ToHand(this HandDTO handDTO) => _mapper.Map<HandDTO, Hand>(handDTO);

    }


}
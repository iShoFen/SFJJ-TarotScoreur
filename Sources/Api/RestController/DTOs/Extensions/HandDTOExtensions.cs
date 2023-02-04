using Model.Games;
using System;
using AutoMapper;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
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
                    .ForMember(h => h.Petit, opt => opt.MapFrom(h => h.Petit.ToPetitResultsDTO()))
                    .ForMember(h => h.Chelem, opt => opt.MapFrom(h => h.Chelem.ToChelemDTO()))
                    .ForMember(h => h.Biddings, opt => opt.MapFrom(h => h.Biddings.ToBiddingPoigneeDTO()));
                cfg.CreateMap<Hand, HandDTOGetRequest>()
                    .ForMember(h => h.Petit, opt => opt.MapFrom(h => h.Petit.ToPetitResultsDTO()))
                    .ForMember(h => h.Chelem, opt => opt.MapFrom(h => h.Chelem.ToChelemDTO()));
                cfg.CreateMap<HandDTO, Hand>()
                    .ForMember(h => h.Petit, opt => opt.MapFrom(h => h.Petit.ToPetitResults()))
                    .ForMember(h => h.Chelem, opt => opt.MapFrom(h => h.Chelem.ToChelem()));
            });
            _mapper = new Mapper(_mapperConfig);
        }

        /// <summary>
        /// This method maps a Hand to a HandDTO
        /// </summary>
        /// <param name="hand">The hand to map</param>
        /// <returns>The mapped handDTO</returns>
        public static HandDTO ToHandDTO(this Hand hand) => _mapper.Map<Hand, HandDTO>(hand);
        
        /// <summary>
        /// This method maps a Hand to a HandDTOGetRequest
        /// </summary>
        /// <param name="hand">The hand to map</param>
        /// <returns>The mapped HandDTOGetRequest</returns>
        public static HandDTOGetRequest ToHandDTOGetRequest(this Hand hand) => _mapper.Map<Hand, HandDTOGetRequest>(hand);
        
        /// <summary>
        /// Ths method maps a HandDTO to a Hand
        /// </summary>
        /// <param name="handDTO">The handDTO to map</param>
        /// <returns>The mapped hand</returns>
        public static Hand ToHand(this HandDTO handDTO) => _mapper.Map<HandDTO, Hand>(handDTO);

    }
}
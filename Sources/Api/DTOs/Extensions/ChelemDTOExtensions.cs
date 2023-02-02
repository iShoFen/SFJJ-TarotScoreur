using AutoMapper;
using DTOs.Enums;
using Model.Enums;

namespace DTOs.Extensions
{
    public static class ChelemDTOExtensions
    {
        private static MapperConfiguration _mapperConfig;
        private static Mapper _mapper;
        
        /// <summary>
        /// Constructor for the ChelemDTOExtensions class
        /// </summary>
        static ChelemDTOExtensions()
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chelem, ChelemDTO>();
                cfg.CreateMap<ChelemDTO, Chelem>();
            });
            _mapper = new Mapper(_mapperConfig);
        }
        
        /// <summary>
        /// This method maps a Chelem to a ChelemDTO
        /// </summary>
        /// <param name="chelem">The Chelem to map</param>
        /// <returns>The mapped ChelemDTO</returns>
        public static ChelemDTO ToChelemDTO(this Chelem chelem) => _mapper.Map<Chelem, ChelemDTO>(chelem);
        
        /// <summary>
        /// Ths method maps a ChelemDTO to a Chelem
        /// </summary>
        /// <param name="chelemDTO">The ChelemDTO to map</param>
        /// <returns>The mapped Chelem</returns>
        public static Chelem ToChelem(this ChelemDTO chelemDTO) => _mapper.Map<ChelemDTO, Chelem>(chelemDTO);
    }
    
}


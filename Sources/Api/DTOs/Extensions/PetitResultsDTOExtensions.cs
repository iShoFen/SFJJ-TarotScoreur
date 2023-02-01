using AutoMapper;
using DTOs.Enums;
using Model.Enums;
using AutoMapper;

namespace DTOs.Extensions
{
    public static class PetitResultsDTOExtensions
    {
        private static MapperConfiguration _mapperConfig;
        private static Mapper _mapper;
       
        /// <summary>
        /// Constructor for the PetitResultsDTOExtensions class
        /// </summary>
        static PetitResultsDTOExtensions()
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PetitResults, PetitResultsDTO>();
                cfg.CreateMap<PetitResultsDTO, PetitResults>();
            });
            _mapper = new Mapper(_mapperConfig);
        }

        /// <summary>
        /// This method maps a PetitResultsDTO to a PetitResults
        /// </summary>
        /// <param name="petitResults">The PetitResults to map</param>
        /// <returns>The mapped PetitResults</returns>
        public static PetitResultsDTO ToPetitResultsDTO(this PetitResults petitResults) => _mapper.Map<PetitResults, PetitResultsDTO>(petitResults);
        
        /// <summary>
        /// Ths method maps a PetitResults to a PetitResultsDTO
        /// </summary>
        /// <param name="petitResultsDTO">The PetitResultsDTO to map</param>
        /// <returns>The mapped PetitResultsDTO</returns>
        public static PetitResults ToPetitResults(this PetitResultsDTO petitResultsDTO) => _mapper.Map<PetitResultsDTO, PetitResults>(petitResultsDTO);

    }
}



using AutoMapper;
using Model.Enums;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
{
    public static class PetitResultsDTOExtensions
    {
        private static readonly MapperConfiguration MapperConfig = new (cfg =>
        {
            cfg.CreateMap<PetitResults, PetitResultsDTO>();
            cfg.CreateMap<PetitResultsDTO, PetitResults>();
        });
        private static readonly Mapper Mapper =new (MapperConfig);

        /// <summary>
        /// This method maps a PetitResults to a PetitResultsDTO
        /// </summary>
        /// <param name="petitResults">The PetitResults to map</param>
        /// <returns>The mapped PetitResultsDTO</returns>
        public static PetitResultsDTO ToPetitResultsDTO(this PetitResults petitResults) => Mapper.Map<PetitResults, PetitResultsDTO>(petitResults);
        
        /// <summary>
        /// Ths method maps a PetitResultsDTO to a PetitResults
        /// </summary>
        /// <param name="petitResultsDTO">The PetitResultsDTO to map</param>
        /// <returns>The mapped PetitResults</returns>
        public static PetitResults ToPetitResults(this PetitResultsDTO petitResultsDTO) => Mapper.Map<PetitResultsDTO, PetitResults>(petitResultsDTO);

    }
}
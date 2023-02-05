using AutoMapper;
using Model.Enums;
using RestController.DTOs.Enums;

namespace RestController.DTOs.Extensions
{
    public static class ChelemDTOExtensions
    {
        private static readonly MapperConfiguration MapperConfig = new(cfg =>
        {
            cfg.CreateMap<Chelem, ChelemDTO>();
            cfg.CreateMap<ChelemDTO, Chelem>();
        });
        private static readonly Mapper Mapper = new(MapperConfig);

        /// <summary>
        /// This method maps a Chelem to a ChelemDTO
        /// </summary>
        /// <param name="chelem">The Chelem to map</param>
        /// <returns>The mapped ChelemDTO</returns>
        public static ChelemDTO ToChelemDTO(this Chelem chelem) => Mapper.Map<Chelem, ChelemDTO>(chelem);
        
        /// <summary>
        /// Ths method maps a ChelemDTO to a Chelem
        /// </summary>
        /// <param name="chelemDTO">The ChelemDTO to map</param>
        /// <returns>The mapped Chelem</returns>
        public static Chelem ToChelem(this ChelemDTO chelemDTO) => Mapper.Map<ChelemDTO, Chelem>(chelemDTO);
    }
}
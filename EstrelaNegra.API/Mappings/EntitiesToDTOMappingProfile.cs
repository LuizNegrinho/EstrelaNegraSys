using AutoMapper;
using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Equine, HorseDTO>();
            CreateMap<IEnumerable<Equine>, IEnumerable<DropDownDTO>>();//apagar
            CreateMap<EquineGrowth, GrowthDTO>();
            CreateMap<EquineHlthFlwup, HealthDTO>();
            CreateMap<HorseMonitorModel, HorseMonitorDTO>();

        }
    }
}

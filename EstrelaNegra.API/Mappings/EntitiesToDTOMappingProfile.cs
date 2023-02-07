using AutoMapper;
using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Equine, HorseMonitorDTO>();
            CreateMap<IEnumerable<Equine>, IEnumerable<DropDownDTO>>();
        }
    }
}

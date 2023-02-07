using AutoMapper;
using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Interfaces;

namespace EstrelaNegra.API.Applications
{
    public class HorseApplication : IHorseApplication
    {
        private readonly IHorseRepository _horseRepository;
        private readonly IMapper _mapper;

        public HorseApplication(IHorseRepository horseRepository, IMapper mapper)
        {
            _horseRepository = horseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DropDownDTO>> GetHorseList()
        {
            /* #TODO - entender porque o mapper não funcionou aqui.
            var result = await _horseRepository.GetAll();
            var list = _mapper.Map<IEnumerable<DropDownDTO>>(result);
            */
            var list = _horseRepository.GetNameList();

            foreach (var horse in list) 
            {
                horse.HorseName = horse.HorseName.Split().First();
            }
            return list;
        }

        public async Task<HorseMonitorDTO> GetMonitorData(int id)
        {
            var horse = await _horseRepository.GetById(id);
            HorseMonitorDTO monitorData = _mapper.Map<HorseMonitorDTO>(horse);

            monitorData.EquineGrowth = await _horseRepository.GetGrowth(id);
            monitorData.EquineHlthFlwup = await _horseRepository.GetHealth(id);

            return monitorData;
        }
    }
}

using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Interfaces
{
    public interface IHorseApplication
    {
        Task<HorseDTO> GetHorseById(int id);
        Task<IEnumerable<DropDownDTO>> GetHorseList();
        HorseMonitorDTO GetMonitorData(int id);
    }
}

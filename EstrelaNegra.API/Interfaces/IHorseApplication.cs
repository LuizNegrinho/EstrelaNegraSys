using EstrelaNegra.API.DTO;

namespace EstrelaNegra.API.Interfaces
{
    public interface IHorseApplication
    {
        Task<HorseMonitorDTO> GetMonitorData(int id);
        Task<IEnumerable<DropDownDTO>> GetHorseList();
    }
}

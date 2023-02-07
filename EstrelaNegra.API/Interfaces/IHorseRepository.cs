using EstrelaNegra.API.DTO;
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Interfaces
{
    public interface IHorseRepository
    {
        void Add(Equine horse);
        void Update(Equine horse);
        void Delete(Equine horse);
        Task<Equine> GetById(int id);
        Task<ICollection<Equine>> GetAll();
        Task<bool> SaveAllAsync();
        Task<ICollection<EquineGrowth>> GetGrowth(int id);
        Task<ICollection<EquineHlthFlwup>> GetHealth(int id);
        string GetNameById(int id);
        ICollection<DropDownDTO> GetNameList();
    }
}

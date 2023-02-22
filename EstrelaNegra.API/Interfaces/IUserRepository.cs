using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
    }
}
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Controllers
{
    public interface IUserApplication
    {
        IEnumerable<UserModel> GetUsers();
    }
}
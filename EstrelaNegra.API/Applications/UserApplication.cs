using EstrelaNegra.API.Controllers;
using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Models;

namespace EstrelaNegra.API.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}

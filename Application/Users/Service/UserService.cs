using Application.Users.Interface;
using Domain.Entities;
using Domain.Models;

namespace Application.Users.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginUserAsync(UserModel model)
        {
            var user = await _userRepository.GetUser(model);
            return user;
        }
    }
}

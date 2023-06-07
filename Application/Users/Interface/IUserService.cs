using Domain.Entities;
using Domain.Models;

namespace Application.Users.Interface
{
    public interface IUserService
    {
        Task<User> LoginUserAsync(UserModel model);
    }
}

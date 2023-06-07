using Domain.Entities;
using Domain.Models;

namespace Application.Users.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUser(UserModel userModel);
    }
}
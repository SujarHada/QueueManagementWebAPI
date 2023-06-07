using Application.Users.Interface;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OMSDbContext _omsDbContext;

        public UserRepository(OMSDbContext omsDbContext)
        {
            _omsDbContext = omsDbContext;
        }

        public async Task<User> GetUser(UserModel userModel)
        {
            var foundUser = await _omsDbContext.Users.FirstOrDefaultAsync(
                x => x.Email == userModel.Email && x.Password == userModel.Password
            );
            return foundUser;
        }
    }
}
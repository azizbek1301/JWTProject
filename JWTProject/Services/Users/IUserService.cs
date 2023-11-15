using JWTProject.Entities;
using JWTProject.Models;

namespace JWTProject.Services.Users
{
    public interface IUserService
    {
        public ValueTask<IEnumerable<User>> GetUsersAsync();
        public ValueTask<bool> CreateAsync(UserCreateDto userModel);
    }
}

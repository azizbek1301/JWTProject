using JWTProject.DataAccess;
using JWTProject.Entities;
using JWTProject.Models;
using JWTProject.Services.Security;
using Microsoft.EntityFrameworkCore;

namespace JWTProject.Services.Users
{
    public class UserService : IUserService
    {
        private readonly DemoDbContext _context;
        public UserService(DemoDbContext context)
        {
            _context = context;
            
        }
        public async ValueTask<bool> CreateAsync(UserCreateDto userModel)
        {
            User user = new User();
            user.UserName = userModel.UserName;
            user.PasswordHash=Hash512.ComputeHash512(userModel.Password);

            await _context.Users.AddAsync(user);
            int result=await _context.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask<IEnumerable<User>> GetUsersAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }
    }
}

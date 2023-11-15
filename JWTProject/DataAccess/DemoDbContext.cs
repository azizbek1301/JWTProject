using JWTProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTProject.DataAccess
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) 
            : base(options) { }

        public DbSet<User> Users {  get; set; }
    }
}

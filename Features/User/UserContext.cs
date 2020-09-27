using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Features.User
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        { }
    }
}
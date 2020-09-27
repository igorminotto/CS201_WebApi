using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CS201_WebApi.Infra.Database
{
    public class DefaultDatabaseContext : DbContext
    {
        private IConfiguration _configuration;

        public DefaultDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["Database"], c =>
            {
                c.CommandTimeout(1000);
            });
        }
    }
}
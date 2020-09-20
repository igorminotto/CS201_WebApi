using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Infra.Database
{
    public class DefaultDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=todos;User=sa;Password=4dbUi4Cz", c =>
            {
                c.CommandTimeout(1000);
            });
        }
    }
}
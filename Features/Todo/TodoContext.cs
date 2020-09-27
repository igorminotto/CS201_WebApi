using CS201_WebApi.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CS201_WebApi.Features.Todo
{
    public class TodoContext : DefaultDatabaseContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(IConfiguration configuration): base(configuration)
        { }
    }
}
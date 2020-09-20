using CS201_WebApi.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Features.Todo
{
    public class TodoContext : DefaultDatabaseContext
    {
        public DbSet<Todo> Todos { get; set; }
    }
}
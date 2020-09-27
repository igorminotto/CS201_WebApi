using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Features.Todo
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions options) : base(options)
        { }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS201_WebApi.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Features.Todo
{
    public class TodoRepository : AbstractRepository<Todo>
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext) : base(todoContext)
        {
            _todoContext = todoContext;
        }

        public override async Task<IEnumerable<Todo>> GetAll() => await Entities
            .AsNoTracking()
            .Include(t => t.User)
            .OrderBy(t => t.CreateDate)
            .ToListAsync();
    }
}
using CS201_WebApi.Infra.Database;

namespace CS201_WebApi.Features.Todo
{
    public class TodoRepository : AbstractRepository<Todo>
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext) : base(todoContext)
        {
            _todoContext = todoContext;
        }
    }
}
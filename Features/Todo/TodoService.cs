using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CS201_WebApi.Features.Todo
{
    public class TodoService
    {
        private readonly TodoContext _todoContext;

        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos() => await _todoContext.Todos
            .OrderBy(t => t.CreateDate)
            .ToListAsync();

        public async Task<Todo> GetTodo(int id) => await _todoContext.Todos
            .SingleAsync(t => t.Id == id);

        public async Task<Todo> InsertTodo(TodoDTO todoDTO)
        { 
            var todo = Todo.FromDTO(todoDTO);
            
            _todoContext.Todos.Add(todo);
            await _todoContext.SaveChangesAsync();

            return todo;
        }

        public async Task<Todo> UpdateTodo(int id, TodoDTO todoDTO)
        {
            var todo = await GetTodo(id);
            todo.UpdateFields(todoDTO);
            
            _todoContext.Todos.Update(todo);
            await _todoContext.SaveChangesAsync();

            return todo;
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await GetTodo(id);
            _todoContext.Remove(todo);
            await _todoContext.SaveChangesAsync();
        }
    }
}
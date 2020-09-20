using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS201_WebApi.Features.Todo
{
    public class TodoService
    {
        private readonly TodoRepository _todoRepository;

        public TodoService(TodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos() => await _todoRepository.GetAll();

        public async Task<Todo> GetTodo(int id) => await _todoRepository.GetById(id);

        public async Task<Todo> InsertTodo(TodoDTO todoDTO)
        { 
            var todo = Todo.FromDTO(todoDTO);
            return await InsertTodo(todo);
        }

        public async Task<Todo> InsertTodo(Todo todo) => await _todoRepository.Insert(todo);


        public async Task<Todo> UpdateTodo(int id, TodoDTO todoDTO)
        {
            var todo = await GetTodo(id);
            todo.UpdateFields(todoDTO);
            return await UpdateTodo(todo);
        }

        public async Task<Todo> UpdateTodo(Todo todo) => await _todoRepository.Update(todo);

        public async Task DeleteTodo(int id)
        {
            var todo = await GetTodo(id);
            await DeleteTodo(todo);
        }

        public async Task DeleteTodo(Todo todo) => await _todoRepository.Delete(todo);
    }
}
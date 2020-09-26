using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS201_WebApi.Features.Todo
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoService _todoService;

        public TodoController(ILogger<TodoController> logger, TodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll() => await _todoService.GetAllTodos();

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Todo> Get([FromRoute] int id) => await _todoService.GetTodo(id);

        [HttpPost]
        public async Task<Todo> Insert([FromBody] TodoDTO todoDto) => 
            await _todoService.InsertTodo(todoDto);

        [HttpPut]
        [Route("{id:int}")]
        public async Task<Todo> Update([FromRoute] int id, [FromBody] TodoDTO todoDto) => 
            await _todoService.UpdateTodo(id, todoDto);

        [HttpPatch]
        [Route("{id:int}")]
        // Limitação: case sensitive + build warnings
        public async Task<Todo> Update([FromRoute] int id, [FromBody] Delta<TodoDTO> todoPatch) =>
            await _todoService.UpdateTodo(id, todoPatch);
            
        // Limitação: json complexo
        // public async Task<Todo> Update([FromRoute] int id, [FromBody] JsonPatchDocument<TodoDTO> todoPatch) =>
        //     await _todoService.UpdateTodo(id, todoPatch);

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete([FromRoute] int id) => await _todoService.DeleteTodo(id);
    }
}

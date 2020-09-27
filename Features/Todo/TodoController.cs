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
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Gets all TodoItems.
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll() => await _todoService.GetAllTodos();

        /// <summary>
        /// Gets a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>  
        [HttpGet]
        [Route("{id:int}")]
        public async Task<Todo> Get([FromRoute] int id) => await _todoService.GetTodo(id);

        /// <summary>
        /// Creates a TodoItems.
        /// </summary>
        [HttpPost]
        public async Task<Todo> Insert([FromBody] TodoDTO todoDto) => 
            await _todoService.InsertTodo(todoDto);

        /// <summary>
        /// Updates a TodoItem.
        /// </summary>
        /// <body>TodoDTO</body>
        /// <param name="id"></param>  
        [HttpPut]
        [Route("{id:int}")]
        public async Task<Todo> Update([FromRoute] int id, [FromBody] TodoDTO todoDto) => 
            await _todoService.UpdateTodo(id, todoDto);

        /// <summary>
        /// Updates some fields of a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Patch /Todo/:id
        ///     {
        ///        "Title": "Test",
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>  
        [HttpPatch]
        [Route("{id:int}")]
        // Limitação: case sensitive + build warnings
        public async Task<Todo> Update([FromRoute] int id, [FromBody] Delta<TodoDTO> todoPatch) =>
            await _todoService.UpdateTodo(id, todoPatch);

        // Limitação: json complexo
        // public async Task<Todo> Update([FromRoute] int id, [FromBody] JsonPatchDocument<TodoDTO> todoPatch) =>
        //     await _todoService.UpdateTodo(id, todoPatch);

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>  
        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete([FromRoute] int id) => await _todoService.DeleteTodo(id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS201_WebApi.Features.Todo
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Todo
            {
                Id = index,
                CreateDate = DateTime.Now.AddDays(index),
                Title = "teste"
            })
            .ToArray();
        }
    }
}

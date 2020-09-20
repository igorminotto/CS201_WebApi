using System;
using System.ComponentModel.DataAnnotations;
using CS201_WebApi.Infra.Database;

namespace CS201_WebApi.Features.Todo
{
    public class Todo : Entity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsDone { get; set; } = false;

        public static Todo FromDTO(TodoDTO todoDTO)
        {
            var todo = new Todo();
            todo.UpdateFields(todoDTO);

            return todo;
        } 

        public void UpdateFields(TodoDTO todoDTO)
        {
            Title = todoDTO.Title;
            Content = todoDTO.Content;
            IsDone = todoDTO.IsDone;
        }
    }
}

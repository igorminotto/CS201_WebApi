using System;
using System.ComponentModel.DataAnnotations;

namespace CS201_WebApi.Features.Todo
{
    public class Todo
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsDone { get; set; } = false;

        public static Todo FromDTO(TodoDTO todoDTO)
        {
            var todo = new Todo 
            {
                CreateDate = DateTime.Now
            };
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

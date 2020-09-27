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

        [Required]
        public User.User User { get; set; }

        public static Todo FromDTO(TodoDTO todoDTO)
        {
            var todo = new Todo();
            todo.UpdateFields(todoDTO);

            return todo;
        } 

        public TodoDTO ToDTO() => new TodoDTO
        {
            Title = Title,
            Content = Content,
            IsDone = IsDone,
        };

        public void UpdateFields(TodoDTO todoDTO)
        {
            Title = todoDTO.Title;
            Content = todoDTO.Content;
            IsDone = todoDTO.IsDone;
        }
    }
}

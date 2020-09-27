using System.ComponentModel.DataAnnotations;

namespace CS201_WebApi.Features.Todo
{
    public class TodoDTO
    {
        [Required, MinLength(6), MaxLength(63)]
        public string Title { get; set; }

        [Required, MinLength(2), MaxLength(255)]
        public string Content { get; set; }

        public bool IsDone { get; set; } = false;
    }
}

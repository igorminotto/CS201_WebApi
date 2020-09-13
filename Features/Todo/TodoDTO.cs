using System;

namespace CS201_WebApi.Features.Todo
{
    public class TodoDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDone { get; set; } = false;
    }
}

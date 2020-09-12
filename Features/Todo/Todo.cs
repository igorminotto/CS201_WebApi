using System;

namespace CS201_WebApi.Features.Todo
{
    public class Todo
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}

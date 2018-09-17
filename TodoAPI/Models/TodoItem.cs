using System;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public long? UserId { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
        
    }
}
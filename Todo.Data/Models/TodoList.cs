using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Data.Models
{
    public class TodoList
    {
        public TodoList() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public long? UserId { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}

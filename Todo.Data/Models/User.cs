using System.Collections.Generic;

namespace Todo.Data.Models
{
    public class User
    {
        public User() {

        }

        public long Id { get; set; }

        public string Name { get; set; }

        public List<TodoItem> TodoItems { get; set; }
        public List<TodoList> TodoLists { get; set; }
    }
}

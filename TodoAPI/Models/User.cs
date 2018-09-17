using System.Collections.Generic;

namespace TodoAPI.Models
{
    public class User
    {
        public User() {

        }

        public long Id { get; set; }

        public string Name { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}

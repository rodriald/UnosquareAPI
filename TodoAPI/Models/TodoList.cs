using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public long UserId { get; set; }
        public List<TodoItem> ItemsList { get; set; }
    }
}

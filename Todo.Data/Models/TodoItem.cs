namespace Todo.Data.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public long? UserId { get; set; }

        public long? TodoListId { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

    }
}
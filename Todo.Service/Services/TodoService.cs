using System.Collections.Generic;
using System.Linq;
using Todo.Data.Models;

public class TodoService : IApiService<TodoItem>
{

    private readonly TodoContext _context;

    public TodoService(TodoContext context){
        _context = context;
    }
    
    public long Create(TodoItem item)
    {
        _context.TodoItems.Add(item);
        _context.SaveChanges();
        return item.Id;
    }

    public TodoItem Delete(long id)
    {
        var item = _context.TodoItems.Find(id);
        if (item == null)
        {
            return null;
        }

        _context.TodoItems.Remove(item);
        _context.SaveChanges();

        return item;
    }

    public List<TodoItem> GetAll()
    {
        return _context.TodoItems.ToList();
    }

    public TodoItem GetById(long id)
    {
        return _context.TodoItems.Find(id);
    }

    public TodoItem Update(long id, TodoItem item)
    {
        var todo = _context.TodoItems.Find(id);
        if (todo == null)
        {
            return null;
        }

        todo.IsComplete = item.IsComplete;
        todo.Name = item.Name;
        todo.UserId = item.UserId;
        todo.TodoListId = item.TodoListId;

        _context.TodoItems.Update(todo);
        _context.SaveChanges();
        return item;
    }
}
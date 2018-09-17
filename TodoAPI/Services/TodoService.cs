using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

public class TodoService : IApiService<TodoItem>
{

    private readonly TodoContext _context;

    public TodoService(TodoContext context){
        _context = context;
    }
    
    public void Create(TodoItem item)
    {
        _context.TodoItems.Add(item);
        _context.SaveChanges();
    }

    public TodoItem Delete(long id)
    {
        var todo = _context.TodoItems.Find(id);
        if (todo == null)
        {
            return null;
        }

        _context.TodoItems.Remove(todo);
        _context.SaveChanges();

        return todo;
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

        /*Properties test*/
        PropertyInfo[] properties = typeof(TodoItem).GetProperties();
        foreach (PropertyInfo property in properties) {
            if(!property.Name.Equals("Id"))
                property.SetValue(todo, property.GetValue(item));
        }
        /**/
        todo.IsComplete = item.IsComplete;
        todo.Name = item.Name;
        todo.UserId = item.UserId;
        

        _context.TodoItems.Update(todo);
        _context.SaveChanges();
        return item;
    }
}
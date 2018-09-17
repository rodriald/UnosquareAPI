
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

public interface ITodoService
{
    List<TodoItem> GetAll();

    TodoItem GetById(long id);
    void Create(TodoItem item);
    TodoItem Delete(long id);
    TodoItem Update(long id, TodoItem item);
}
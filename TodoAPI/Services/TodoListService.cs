using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoListService : IApiService<TodoList>
    {
        private readonly TodoContext _context;

        public TodoListService(TodoContext context)
        {
            _context = context;
        }

        public long Create(TodoList list, out string todotype)
        {
            _context.TodoLists.Add(list);
            _context.SaveChanges();
            todotype = "GetTodoList";
            return list.Id;
        }

        public TodoList Delete(long id)
        {
            var list = _context.TodoLists.Find(id);
            if (list == null)
            {
                return null;
            }

            _context.TodoLists.Remove(list);
            _context.SaveChanges();

            return list;
        }

        public List<TodoList> GetAll()
        {
            return _context.TodoLists.Include(x => x.TodoItems).ToList();
        }

        public TodoList GetById(long id)
        {
            return _context.TodoLists.Include(x => x.TodoItems)
            .SingleOrDefault(x => x.Id == id);
        }

        public TodoList Update(long id, TodoList list)
        {
            var oldList = _context.Users.Include(x => x.TodoItems)
            .SingleOrDefault(x => x.Id == id);

            if (oldList == null)
            {
                return null;
            }

            oldList.Name = list.Name;
            oldList.TodoItems = list.TodoItems;

            _context.Users.Update(oldList);
            _context.SaveChanges();
            return list;
        }
    }
}

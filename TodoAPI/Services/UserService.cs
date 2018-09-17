using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

public class UserService : IApiService<User>
{
    private readonly TodoContext _context;

    public UserService(TodoContext context) {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User Delete(long id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return null;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return user;
    }

    public List<User> GetAll()
    {
        return _context.Users.Include(x => x.TodoItems).ToList();
    }

    public User GetById(long id)
    {
        return _context.Users.Include(x => x.TodoItems)
            .SingleOrDefault(x => x.Id == id);
    }

    public User Update(long id, User user)
    {
        var oldUser = _context.Users.Include(x => x.TodoItems)
            .SingleOrDefault(x => x.Id == id);
        
        if (oldUser == null)
        {
            return null;
        }

        oldUser.Name = user.Name;
        oldUser.TodoItems = user.TodoItems;

        _context.Users.Update(oldUser);
        _context.SaveChanges();
        return user;
    }
}


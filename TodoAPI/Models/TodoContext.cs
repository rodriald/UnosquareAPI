using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoAPI.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext() { }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
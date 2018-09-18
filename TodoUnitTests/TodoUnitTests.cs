using Xunit;
using Todo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TodoUnitTests
{
    public class TodopUnitTest
    {
        [Fact]
        public void CreateTodo()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoService(context);
                TodoItem item = new TodoItem();
                item.Name = "Go to store";
                item.IsComplete = false;
                service.Create(item);
            }
            using (var context = new TodoContext(options))
            {

                Assert.Equal(1, context.TodoItems.ToList().Count);
            }
        }

        [Fact]
        public void UpdateTodo()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoService(context);
                TodoItem item = new TodoItem();
                item.Name = "go to store";
                item.Id = 1;
                item.IsComplete = false;
                service.Create(item);
                TodoItem newItem = new TodoItem();
                newItem.Name = "go to movies";
                Assert.NotEqual(item, service.Update(1, newItem));
            }
        }

        [Fact]
        public void DeleteTodo()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoService(context);
                TodoItem item = new TodoItem();
                item.Name = "Go to store";
                item.Id = 1;
                item.IsComplete = false;
                service.Create(item);
                service.Delete(1);
                Assert.Equal(0, context.TodoItems.ToList().Count);
            }
        }

        [Fact]
        public void SearchTodo()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoService(context);
                TodoItem item = new TodoItem();
                item.Name = "go to store";
                item.Id = 1;
                item.IsComplete = false;
                service.Create(item);
                Assert.Equal(service.GetById(1), item);
            }
        }
    }
}
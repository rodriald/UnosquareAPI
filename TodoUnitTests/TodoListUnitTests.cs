using Xunit;
using Todo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TodoAPI.Services;

namespace TodoUnitTests
{
    public class TodoListUnitTests
    {
        [Fact]
        public void CreateList()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoListService(context);
                TodoList list = new TodoList();
                list.Name = "New list";
                service.Create(list);
            }
            using (var context = new TodoContext(options))
            {

                Assert.Equal(1, context.TodoLists.ToList().Count);
            }
        }

        [Fact]
        public void UpdateList()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoListService(context);
                TodoList list = new TodoList();
                list.Name = "New List";
                list.Id = 1;
                service.Create(list);
                TodoList newList= new TodoList();
                newList.Name = "Old list";
                Assert.NotEqual(list, service.Update(1, newList));
            }
        }

        [Fact]
        public void DeleteList()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoListService(context);
                TodoList list = new TodoList();
                list.Name = "New list";
                list.Id = 1;
                service.Create(list);
                service.Delete(1);
                Assert.Equal(0, context.TodoLists.ToList().Count);
            }
        }

        [Fact]
        public void SearchList()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new TodoListService(context);
                TodoList list = new TodoList();
                list.Name = "New list";
                list.Id = 1;
                service.Create(list);
                Assert.Equal(service.GetById(1), list);
            }
        }
    }
}

using Xunit;
using TodoAPI.Models;
using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoUnitTests
{
    public class UserUnitTests
    {
        [Fact]
        public void CreateUser()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new UserService(context);
                User user = new User();
                user.Name = "Aldo";
                service.Create(user);
            }
            using (var context = new TodoContext(options))
            {

                Assert.Equal(1, context.Users.ToList().Count);
            }
        }

        [Fact]
        public void UpdateUser()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new UserService(context);
                User user= new User();
                user.Name = "Aldo";
                user.Id = 1;
                service.Create(user);
                User newUser = new User();
                newUser.Name = "Jourge";
                Assert.NotEqual(user, service.Update(1, newUser));
            }
        }

        [Fact]
        public void DeleteUser()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new UserService(context);
                User user = new User();
                user.Name = "Aldo";
                user.Id = 1;
                service.Create(user);
                service.Delete(1);
                Assert.Equal(0, context.Users.ToList().Count);
            }
        }

        [Fact]
        public void SearchUser()
        {
            var options = new DbContextOptionsBuilder<TodoContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new TodoContext(options))
            {
                var service = new UserService(context);
                User user = new User();
                user.Name = "Aldo";
                user.Id = 1;
                service.Create(user);
                Assert.Equal(service.GetById(1), user);
            }
        }
    }
}

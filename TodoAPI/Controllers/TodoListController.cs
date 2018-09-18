using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ApiController<TodoList>
    {
        protected override string controllerName => "todolist";

        public TodoListController(IApiService<TodoList> userService) : base(userService) {

        }
    }
}

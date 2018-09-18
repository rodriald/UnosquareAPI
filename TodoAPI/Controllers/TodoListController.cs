using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ApiController<TodoList>
    {
        public TodoListController(IApiService<TodoList> userService) : base(userService) {

        }
    }
}

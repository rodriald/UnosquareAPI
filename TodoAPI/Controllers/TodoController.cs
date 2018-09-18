using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Data.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ApiController<TodoItem>
    {
        public TodoController(IApiService<TodoItem> apiService) : base(apiService)
        {

        }

        protected override string controllerName => "todo";
    }
}
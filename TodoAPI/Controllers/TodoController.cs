using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class TodoController : ApiController<TodoItem>
    {
        public TodoController(IApiService<TodoItem> apiService):base(apiService)
        {
            
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public override ActionResult<TodoItem> GetById(long id)
        {
            return base.GetById(id);
        }
    }
}
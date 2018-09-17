using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IApiService<TodoItem> _todoService;

        public TodoController(IApiService<TodoItem> todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _todoService.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _todoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _todoService.Create(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Update(id, item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _todoService.Delete(id);
            if (todo == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class TodoController : ApiController<TodoItem>
    {
        private readonly IApiService<TodoItem> _todoService;

        public TodoController(IApiService<TodoItem> apiService):base(apiService)
        {
            _todoService = apiService;
        }

        
        public override ActionResult<List<TodoItem>> GetAll()
        {
            return _todoService.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public override ActionResult<TodoItem> GetById(long id)
        {
            var item = _todoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        
        public override IActionResult Create(TodoItem item)
        {
            _todoService.Create(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        
        public override IActionResult Update(long id, TodoItem item)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Update(id, item);

            return NoContent();
        }

        
        public override IActionResult Delete(long id)
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
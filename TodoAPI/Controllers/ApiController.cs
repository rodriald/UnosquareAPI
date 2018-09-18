using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{

    public abstract class ApiController<T> : ControllerBase
    {

        protected abstract string controllerName { get; }

        private readonly IApiService<T> _apiService;


        public ApiController(IApiService<T> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public virtual ActionResult<List<T>> GetAll()
        {
            return _apiService.GetAll();
        }

        [HttpGet("{id}")]
        public virtual ActionResult<T> GetById(long id)
        {
            var item = _apiService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public virtual IActionResult Create(T item)
        {
            long itemId = _apiService.Create(item);
            return Ok();
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(long id, T item)
        {
            var oldItem = _apiService.GetById(id);
            if (oldItem == null)
            {
                return NotFound();
            }

            _apiService.Update(id, item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(long id)
        {
            var item = _apiService.Delete(id);
            if (item == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

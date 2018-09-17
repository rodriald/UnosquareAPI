using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController<T> : ControllerBase
    {

        private readonly IApiService<T> _apiService;

        public IApiService<T> ApiService { get { return _apiService; } }

        public ApiController(IApiService<T> apiService) {
            _apiService = apiService;
        }

        [HttpGet]
        public virtual ActionResult<List<T>> GetAll() {
            return ApiService.GetAll();
        }

        [HttpGet("{id}", Name = "GetItem")]
        public virtual ActionResult<T> GetById(long id) {
            var user = _apiService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public virtual IActionResult Create(T item) {
            ApiService.Create(item);
            return CreatedAtRoute("GetItem", new { id = typeof(T).GetProperty("Id").GetValue(item) }, item);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(long id, T item) {
            var user = _apiService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _apiService.Update(id, item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(long id) {
            var user = _apiService.Delete(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

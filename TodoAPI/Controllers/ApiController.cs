using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;
using System.Collections.Generic;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController<T> : ControllerBase
    {
        [HttpGet]
        public abstract ActionResult<List<T>> GetAll();

        [HttpGet("{id}", Name = "GetItem")]
        public abstract ActionResult<T> GetById(long id);

        [HttpPost]
        public abstract IActionResult Create(T item);

        [HttpPut("{id}")]
        public abstract IActionResult Update(long id, T item);

        [HttpDelete("{id}")]
        public abstract IActionResult Delete(long id);
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController<User>
    {
        private readonly IApiService<User> _userService;

        public UserController(IApiService<User> userService)
        {
            _userService = userService;
        }

        public override ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public override ActionResult<User> GetById(long id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        public override IActionResult Create(User item)
        {
            _userService.Create(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        public override IActionResult Update(long id, User item)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, item);

            return NoContent();
        }

        public override IActionResult Delete(long id)
        {
            var user = _userService.Delete(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
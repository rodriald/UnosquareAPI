using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userService.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, User newUser)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, newUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
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
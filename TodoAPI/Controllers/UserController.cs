using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class UserController : ApiController<User>
    {
        public UserController(IApiService<User> userService):base(userService)
        {
            
        }

        [HttpGet("{id}", Name = "GetUser")]
        public override ActionResult<User> GetById(long id)
        {
            return base.GetById(id);
        }
    }
}
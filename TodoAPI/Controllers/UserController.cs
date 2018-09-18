using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Data.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController<User>
    {
        protected override string controllerName => "user";

        public UserController(IApiService<User> userService) : base(userService)
        {

        }
    }
}
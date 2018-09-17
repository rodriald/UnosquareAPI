using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController<User>
    {
        public UserController(IApiService<User> userService) : base(userService)
        {

        }
    }
}
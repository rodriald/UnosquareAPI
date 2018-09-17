using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class UserController : ApiController<User>
    {
        //private readonly IApiService<User> _userService;

        public UserController(IApiService<User> userService):base(userService)
        {
            
        }

        public override IActionResult Create(User item)
        {
            ApiService.Create(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
        
    }
}
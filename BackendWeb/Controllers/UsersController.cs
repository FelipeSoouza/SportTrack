using Microsoft.AspNetCore.Mvc;
using WebSport.Models;
using WebSport.Services;
using System.Collections.Generic;

namespace WebSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly MongoService<User> _service;

        public UsersController(MongoService<User> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = _service.Get();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _service.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
    }
}

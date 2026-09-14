using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User { FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com" },
                new User { FirstName = "Bob", LastName = "Smith", Email = "bob@example.com" },
                new User { FirstName = "Charlie", LastName = "Davis", Email = "charlie@example.com" }
            };

            return Ok(users);
        }
    }
}

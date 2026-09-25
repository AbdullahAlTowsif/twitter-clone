using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            var newUser = new User
            {
                FirstName = "David",
                LastName = "Wilson",
                Email = "david@example.com"
            };
            return Ok(newUser);
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok(new
            {
                UserId = id,
                UserName = "user"+ id.ToString(),
            });
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id)
        {
            return Ok(new
            {
                UserId = id,
                UserName = "updatedUser" + id.ToString(),
            });
        }


        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id,  [FromBody] string phoneNumber)
        {
            return Ok(new
            {
                UserId = id,
                PhoneNumber = phoneNumber,
            });
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            return Ok(new
            {
                UserId = id,
                Message = "User deleted successfully!",
            });
        }
    }
}

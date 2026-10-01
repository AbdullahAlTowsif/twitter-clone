using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UsersController(UserRepository userRepository) // Dependency Injection
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();

            return Ok(users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            }));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return BadRequest("All fields are required!");
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null)
            {
                return BadRequest("A user with this email already exists!");
            }

            var createdUser = _userRepository.AddUser(new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            });

            return Ok(new UserDto
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            });
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            _userRepository.UpdateUser(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }


        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
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
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var isDeleted = _userRepository.DeleteUser(user);

            return Ok(isDeleted);
        }
    }
}

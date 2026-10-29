using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    public class AuthController : ControllerBase // Inherit from ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) // Dependency Injection
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var authResponse = _authService.Login(loginDto);
            if(authResponse == null)
            {
                return Unauthorized(); // Use the Unauthorized() helper method
            }
            return Ok(authResponse);
        }
    }
}

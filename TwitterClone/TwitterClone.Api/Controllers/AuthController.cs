using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase // Inherit from ControllerBase
    {
        // AuthService k ami AuthController e inject korsi. So eigula DI Container e register kora lagbe.
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) // Dependency Injection
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
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

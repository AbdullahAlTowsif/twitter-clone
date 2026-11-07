using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}

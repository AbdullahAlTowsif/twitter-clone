using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateOnly) GetToken(UserDto user);
    }
}

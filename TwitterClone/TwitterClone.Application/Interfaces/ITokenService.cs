using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateTime) GetToken(UserDto user);
    }
}

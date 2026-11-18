using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(UserDto user, string password, string passwordHash);
        string Hash(UserDto user, string password);
    }
}

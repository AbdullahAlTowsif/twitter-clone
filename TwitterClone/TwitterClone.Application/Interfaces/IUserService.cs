using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto? CreateUser(CreateUserDto createUserDto);
        UserDto? GetUserById(Guid id);
        UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
        bool DeleteUser(Guid id);
        List<UserDto> GetUsers();
    }
}

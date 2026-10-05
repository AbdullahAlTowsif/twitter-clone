using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITweetRepository _tweetRepository;

        public UserService(IUserRepository userRepository, ITweetRepository tweetRepository)
        {
            _userRepository = userRepository;
            _tweetRepository = tweetRepository;
        }

        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return null;
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            });

            return createdUser.ToDto();
        }

        public bool DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null)
            {
                return false;
            }

            // TODO: A users tweets can't outlive the user
            _tweetRepository.DeleteTweetsByUserId(id);
            return _userRepository.DeleteUser(user);
        }

        public UserDto? GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return user?.ToDto();
        }

        public List<UserDto> GetUsers()
        {
            return _userRepository.GetUsers().OrderBy(u => u.CreatedAt).Select(u => u.ToDto()).ToList();
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = updateUserDto.FirstName.Trim();
            user.LastName = updateUserDto.LastName.Trim();

            _userRepository.UpdateUser(user);

            return user.ToDto();
        }
    }
}

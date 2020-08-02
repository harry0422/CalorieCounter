using CaloriesCounter.Users.Application.Contract;
using CaloriesCounter.Users.Application.Mappings;
using CaloriesCounter.Users.Domain.Model;
using CaloriesCounter.Users.Domain.Repositories;

namespace CaloriesCounter.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetUserBy(CredentialsDto dto)
        {
            User user = _userRepository.GetBy(dto.Email, dto.Password);
            if (user == null) throw new System.Exception("Invalid credentials.");

            return user.ToDto();
        }

        public UserDto GetUserBy(UserIdDto dto)
        {
            User user = _userRepository.Get(dto.Id);
            if (user == null) throw new System.Exception("User does not exist.");

            return user.ToDto();
        }

        public void CreateUser(CreateUserDto dto)
        {
            User user = _userRepository.GetBy(dto.Email);
            
            if (user != null) throw new System.Exception("User already exists.");


            User newUser = new User(dto.Email, dto.Password, dto.Name, dto.Age);

            _userRepository.Insert(newUser);
        }
    }
}
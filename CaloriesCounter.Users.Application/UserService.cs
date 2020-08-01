using CaloriesCounter.Users.Application.Contract;
using CaloriesCounter.Users.Domain.Model;
using CaloriesCounter.Users.Domain.Repositories;

namespace CaloriesCounter.Users.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public void CreateUser(CreateUserDto dto)
        {
            User user = new User(dto.Email, dto.Password, dto.Name, dto.Age);
            _userRepository.Insert(user);
        }
    }
}
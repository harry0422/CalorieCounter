using CalorieCounter.Users.Application.Contract.DTOs;

namespace CalorieCounter.Users.Application.Contract.Services
{
    public interface IUserService
    {
        UserDto GetUserBy(CredentialsDto dto);
        UserDto GetUserBy(UserIdDto dto);
        UserIdDto CreateUser(CreateUserDto dto);
    }
}
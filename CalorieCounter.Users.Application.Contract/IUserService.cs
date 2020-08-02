namespace CalorieCounter.Users.Application.Contract
{
    public interface IUserService
    {
        UserDto GetUserBy(CredentialsDto dto);
        UserDto GetUserBy(UserIdDto dto);
        UserIdDto CreateUser(CreateUserDto dto);
    }
}
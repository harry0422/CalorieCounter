namespace CaloriesCounter.Users.Application.Contract
{
    public interface IUserService
    {
        UserDto GetUserBy(CredentialsDto dto);
        UserDto GetUserBy(UserIdDto dto);
        void CreateUser(CreateUserDto dto);
    }
}
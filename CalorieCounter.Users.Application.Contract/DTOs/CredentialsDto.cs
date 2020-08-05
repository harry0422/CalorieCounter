namespace CalorieCounter.Users.Application.Contract.DTOs
{
    public class CredentialsDto
    {
        public CredentialsDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
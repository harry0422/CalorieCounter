namespace CalorieCounter.Users.Application.Contract
{
    public class UserIdDto
    {
        public UserIdDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
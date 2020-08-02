namespace CalorieCounter.Users.Application.Contract
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
    }
}
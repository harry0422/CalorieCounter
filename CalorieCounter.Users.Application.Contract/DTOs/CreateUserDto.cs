namespace CalorieCounter.Users.Application.Contract.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Gender { get; set; }
        public int DailyActivityId { get; set; }
    }
}
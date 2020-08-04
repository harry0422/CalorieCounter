namespace CalorieCounter.Users.Application.Contract.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Gender { get; set; }
        public string DailyActivity { get; set; }
        public double BMR { get; set; }
        public int DailyCaloriesNeeded { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
    }
}
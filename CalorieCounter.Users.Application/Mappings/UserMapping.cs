using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Domain.Model;

namespace CalorieCounter.Users.Application.Mappings
{
    public static class UserMapping
    {
        public static UserDto ToDto(this User user)
        {
            if (user == null) return null;

            UserDto dto = new UserDto();
            dto.Id = user.Id;
            dto.Email = user.Email;
            dto.Name = user.Name;
            dto.Age = user.Age;
            dto.Weight = user.Weight;
            dto.Height = user.Height;
            dto.Gender = user.Gender.ToString();
            dto.DailyActivity = user.DailyActivity.Description;
            dto.BMR = user.BMR;
            dto.DailyCaloriesNeeded = user.DailyCaloriesNeeded;
            dto.CreationDate = user.CreationDate.ToString("yyyy-MM-dd hh:mm:ss");
            dto.Status = user.Status.ToString();

            return dto;
        }
    }
}
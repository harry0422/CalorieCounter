using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounterApi.DTOs;

namespace CalorieCounterApi.Mappings
{
    public static class UserMapping
    {
        public static CreateUserDto ToDto(this CreateUserRequest request)
        {
            if (request == null) return null;

            CreateUserDto dto = new CreateUserDto();
            dto.Email = request.Email;
            dto.Password = request.Password;
            dto.Name = request.Name;
            dto.Age = request.Age;
            dto.Weight = request.Weight;
            dto.Height = request.Height;
            dto.Gender = request.Gender;
            dto.DailyActivityId = request.DailyActivityId;

            return dto;
        }
    }
}
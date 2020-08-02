using CalorieCounter.Users.Application.Contract;
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

            return dto;
        }
    }
}
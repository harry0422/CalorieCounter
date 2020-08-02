using CalorieCounter.Users.Application.Contract;
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
            dto.CreationDate = user.CreationDate.ToString("yyyy-MM-dd");
            dto.Status = user.Status.ToString();

            return dto;
        }
    }
}
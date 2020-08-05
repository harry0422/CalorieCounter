using CalorieCounter.Common.Domain.Repositories;
using CalorieCounter.Users.Domain.Model;

namespace CalorieCounter.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, string>
    {
        User GetBy(string email);
    }
}
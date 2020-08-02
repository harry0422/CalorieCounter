using CaloriesCounter.Common.Domain.Repositories;
using CaloriesCounter.Users.Domain.Model;

namespace CaloriesCounter.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, string>
    {
        User GetBy(string email, string password);
        User GetBy(string email);
    }
}
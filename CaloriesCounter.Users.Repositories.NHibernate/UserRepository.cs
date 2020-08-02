using CaloriesCounter.Common.Infrastructure.Repositories.Hibernate;
using CaloriesCounter.Users.Domain.Model;
using CaloriesCounter.Users.Domain.Repositories;

namespace CaloriesCounter.Users.Repositories.NHibernate
{
    public class UserRepository : NhRepositoryBase<User, string>, IUserRepository
    {

    }
}
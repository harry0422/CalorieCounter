using CalorieCounter.Common.Repositories.Hibernate;
using CalorieCounter.Users.Domain.Model;
using CalorieCounter.Users.Domain.Repositories;
using System.Linq;

namespace CalorieCounter.Users.Repositories.NHibernate
{
    public class UserRepository : NhRepositoryBase<User, string>, IUserRepository
    {
        public User GetBy(string email)
        {
            return Session.Query<User>()
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }
    }
}
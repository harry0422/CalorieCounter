using CalorieCounter.Common.Repositories.Hibernate;
using CalorieCounter.Users.Domain.Model;
using CalorieCounter.Users.Domain.Repositories;

namespace CalorieCounter.Users.Repositories.NHibernate
{
    public class DailyActivityRepository : NhRepositoryBase<DailyActivity, int>, IDailyActivityRepository
    {

    }
}
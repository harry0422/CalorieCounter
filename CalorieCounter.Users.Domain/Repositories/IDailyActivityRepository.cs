using CalorieCounter.Common.Domain.Repositories;
using CalorieCounter.Users.Domain.Model;

namespace CalorieCounter.Users.Domain.Repositories
{
    public interface IDailyActivityRepository : IRepository<DailyActivity, int>
    {

    }
}
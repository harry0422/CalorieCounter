using CalorieCounter.Users.Application.Contract.DTOs;
using System.Collections.Generic;

namespace CalorieCounter.Users.Application.Contract.Services
{
    public interface IDailyActivityService
    {
        IList<DailyActivityDto> GetDailyActivities();
    }
}
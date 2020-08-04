using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Application.Contract.Services;
using CalorieCounter.Users.Application.Mappings;
using CalorieCounter.Users.Domain.Model;
using CalorieCounter.Users.Domain.Repositories;
using System.Collections.Generic;

namespace CalorieCounter.Users.Application.Services
{
    public class DailyActivityService : IDailyActivityService
    {
        private readonly IDailyActivityRepository _dailyActivityRepository;

        public DailyActivityService(IDailyActivityRepository dailyActivityRepository)
        {
            _dailyActivityRepository = dailyActivityRepository;
        }

        public IList<DailyActivityDto> GetDailyActivities()
        {
            IList<DailyActivity> dailyActivities = _dailyActivityRepository.GetAll();
            return dailyActivities.ToDto();
        }
    }
}
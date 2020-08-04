using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Domain.Model;
using System.Collections.Generic;

namespace CalorieCounter.Users.Application.Mappings
{
    public static class DailyActivityMapping
    {
        public static DailyActivityDto ToDto(this DailyActivity dailyActivity)
        {
            if (dailyActivity == null) return null;

            DailyActivityDto dto = new DailyActivityDto();
            dto.Id = dailyActivity.Id;
            dto.Description = dailyActivity.Description;
            dto.Factor = dailyActivity.Factor;

            return dto;
        }

        public static IList<DailyActivityDto> ToDto(this IList<DailyActivity> dailyActivities)
        {
            if (dailyActivities == null) return null;

            IList<DailyActivityDto> dto = new List<DailyActivityDto>();

            foreach (var da in dailyActivities)
            {
                dto.Add(da.ToDto());
            }

            return dto;
        }
    }
}
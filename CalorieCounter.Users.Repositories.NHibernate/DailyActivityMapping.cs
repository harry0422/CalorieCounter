using CalorieCounter.Users.Domain.Model;
using FluentNHibernate.Mapping;

namespace CalorieCounter.Users.Repositories.NHibernate
{
    public class DailyActivityMapping : ClassMap<DailyActivity>
    {
        public DailyActivityMapping()
        {
            Table("tbl_daily_activities");
            Id(x => x.Id);
            Map(x => x.Description, "description");
            Map(x => x.Factor);
        }
    }
}
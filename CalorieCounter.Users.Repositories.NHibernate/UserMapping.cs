﻿using CalorieCounter.Users.Domain.Model;
using FluentNHibernate.Mapping;

namespace CalorieCounter.Users.Repositories.NHibernate
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("tbl_users");
            Id(x => x.Id, "user_id");
            Map(x => x.Email, "email");
            Map(x => x.Password, "password");
            Map(x => x.Name, "name");
            Map(x => x.Age, "age");
            Map(x => x.Weight, "weight");
            Map(x => x.Height, "height");
            Map(x => x.Gender, "gender");
            References(x => x.DailyActivity, "daily_activity").Not.LazyLoad();
            Map(x => x.CreationDate, "creation_date");
            Map(x => x.Status, "status");
        }
    }
}
using CaloriesCounter.Users.Domain.Model;
using FluentNHibernate.Mapping;

namespace CaloriesCounter.Users.Repositories.NHibernate
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
        }
    }
}
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

namespace CaloriesCounter.Common.Infrastructure.Repositories.Hibernate
{
    public static class NhSessionFactory
    {
        public static ISessionFactory Create(string connectionString)
        {
            try
            {
                return Fluently.Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL82
                    .ConnectionString(connectionString))
                    //.Mappings(c => c.FluentMappings
                    //    .AddFromAssemblyOf<UserMapping>
                    //    .AddFromAssemblyOf<UserMap>)
                    .ExposeConfiguration(cfg => { new SchemaExport(cfg).Create(false, true); })
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
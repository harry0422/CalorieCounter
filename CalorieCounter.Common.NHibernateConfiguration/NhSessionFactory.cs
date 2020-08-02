using CalorieCounter.Users.Repositories.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

namespace CalorieCounter.Common.NHibernateConfiguration
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
                    .Mappings(c => c.FluentMappings.AddFromAssemblyOf<UserMapping>())
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
using Autofac;
using CaloriesCounter.Common.Infrastructure.Repositories.Hibernate;
using CaloriesCounter.CrossCutting.Logs;
using CaloriesCounter.CrossCutting.Transactions;
using NHibernate;
using System;

namespace CaloriesCounter.Common.IoC
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("CALORIESCOUNTER_DB", EnvironmentVariableTarget.User);

            builder.RegisterType<TransactionInterceptor>().SingleInstance();
            builder.RegisterType<LogInterceptor>().SingleInstance();

            builder.RegisterInstance(NhSessionFactory.Create(connectionString))
                .As<ISessionFactory>()
                .SingleInstance();

            builder.RegisterType<NhUnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<NLogLogProvider>().As<ILogProvider>();
        }
    }
}
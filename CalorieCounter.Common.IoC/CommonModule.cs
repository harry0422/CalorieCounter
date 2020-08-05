using Autofac;
using CalorieCounter.Common.Adapters.NetCore;
using CalorieCounter.Common.Domain.Adapters;
using CalorieCounter.Common.NHibernateConfiguration;
using CalorieCounter.CrossCutting.Logs;
using CalorieCounter.CrossCutting.Transactions;
using NHibernate;
using System;

namespace CalorieCounter.Common.IoC
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("CALORIECOUNTER_DB", EnvironmentVariableTarget.User);

            builder.RegisterType<TransactionInterceptor>().SingleInstance();
            builder.RegisterType<LogInterceptor>().SingleInstance();

            builder.RegisterInstance(NhSessionFactory.Create(connectionString))
                .As<ISessionFactory>()
                .SingleInstance();

            builder.RegisterType<NhUnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<NLogLogProvider>().As<ILogProvider>();

            builder.RegisterType<GuidIdentifierGenerator>().As<IIdentifierGenerator>();

            builder.RegisterType<PBKDF2EncryptionProvider>().As<IEncryptionProvider>();
        }
    }
}
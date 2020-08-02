using Autofac;
using Autofac.Extras.DynamicProxy;
using CalorieCounter.CrossCutting.Logs;
using CalorieCounter.CrossCutting.Transactions;
using CalorieCounter.Users.Application.Contract;
using CalorieCounter.Users.Application.Services;
using CalorieCounter.Users.Domain.Repositories;
using CalorieCounter.Users.Repositories.NHibernate;

namespace CalorieCounter.Users.IoC
{
    public class UsersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterType<UserService>()
               .As<IUserService>()
               .EnableInterfaceInterceptors()
               .InterceptedBy(typeof(LogInterceptor));

            builder
               .RegisterType<UserRepository>()
               .As<IUserRepository>()
               .EnableInterfaceInterceptors()
               .InterceptedBy(typeof(TransactionInterceptor));
        }
    }
}
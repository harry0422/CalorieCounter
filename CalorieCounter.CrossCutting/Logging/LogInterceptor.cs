using Castle.DynamicProxy;
using System;

namespace CalorieCounter.CrossCutting.Logs
{
    public class LogInterceptor : IInterceptor
    {
        private readonly ILogProvider _logProvider;

        public LogInterceptor(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logProvider.SaveInfo(invocation);
                invocation.Proceed();
                _logProvider.SaveInfo(invocation);
            }
            catch (Exception e)
            {
                _logProvider.SaveError(invocation, e);
                throw e;
            }

        }
    }
}
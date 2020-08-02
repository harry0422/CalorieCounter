using Castle.DynamicProxy;
using NLog;
using NLog.Web;
using System;

namespace CalorieCounter.CrossCutting.Logs
{
    public class NLogLogProvider : ILogProvider
    {
        private readonly ILogger logger = NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();
        public void SaveError(IInvocation invocation, Exception exception)
        {
            string message = string.Format("Method: {0}, Arguments: {1}, Error: {2}",
                invocation.Method.Name,
                invocation.Arguments.ToString(),
                exception.Message);

            logger.Error(message);
        }

        public void SaveInfo(IInvocation invocation)
        {
            string message = string.Format("Method: {0}, Arguments: {1}",
                 invocation.Method.Name,
                 invocation.Arguments.ToString());

            logger.Info(message);
        }
    }
}
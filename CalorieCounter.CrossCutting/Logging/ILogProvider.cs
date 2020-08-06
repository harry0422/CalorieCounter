using Castle.DynamicProxy;
using System;

namespace CalorieCounter.CrossCutting.Logs
{
    public interface ILogProvider
    {
        void SaveInfo(IInvocation invocation);
        void SaveError(IInvocation invocation, Exception exception);
    }
}
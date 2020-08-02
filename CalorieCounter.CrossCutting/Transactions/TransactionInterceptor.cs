using Castle.DynamicProxy;
using System;

namespace CalorieCounter.CrossCutting.Transactions
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            if (_unitOfWork.SessionExists())
            {
                invocation.Proceed();
                return;
            }

            try
            {
                _unitOfWork.CreateSession();
                _unitOfWork.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    _unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        _unitOfWork.Rollback();
                    }
                    catch (Exception innerE)
                    {
                        throw new Exception(e.Message, innerE);
                    }
                    throw e;
                }
            }
            finally
            {
                _unitOfWork.DisposeSession();
            }
        }
    }
}
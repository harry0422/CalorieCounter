using NHibernate;
using System;

namespace CalorieCounter.CrossCutting.Transactions
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;

        public NhUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [ThreadStatic]
        private static ISession _session;

        [ThreadStatic]
        private ITransaction _transaction;

        public static ISession Session
        {
            get { return _session; }
        }

        public bool SessionExists()
        {
            return !(_session == null);
        }

        public void CreateSession()
        {
            _session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void DisposeSession()
        {
            _session.Close();
            _transaction.Dispose();
            _session.Dispose();
            _transaction = null;
            _session = null;
        }
    }
}
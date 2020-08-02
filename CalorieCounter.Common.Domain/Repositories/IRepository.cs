using CalorieCounter.Common.Domain.Model;
using System.Collections.Generic;

namespace CalorieCounter.Common.Domain.Repositories
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : IAggregateRoot
    {
        IList<TEntity> GetAll();
        TEntity Get(TPrimaryKey key);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TPrimaryKey id);
    }
}
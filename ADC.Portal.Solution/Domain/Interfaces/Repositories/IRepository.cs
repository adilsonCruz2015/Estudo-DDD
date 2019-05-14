using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TIdentifier> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(TIdentifier id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Dispose();

        void Commit();
    }
}

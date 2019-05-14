using System.Collections.Generic;

namespace ADC.Portal.Solution.Application.Interface.Common
{
    public interface IApp<TEntity, TIdentifier> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(TIdentifier id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Dispose();
    }
}

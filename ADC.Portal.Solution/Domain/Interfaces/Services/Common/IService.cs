using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Interfaces.Services.Common
{
    public interface IService<TEntity, TIdentifier> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(TIdentifier id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Dispose();
    }
}

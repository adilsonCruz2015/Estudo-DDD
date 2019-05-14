using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Data.Repositories.Common
{
    public class RepositoryEntityFramework<TEntity, TIdentifier> : IDisposable, 
        IRepository<TEntity, TIdentifier> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TIdentifier id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

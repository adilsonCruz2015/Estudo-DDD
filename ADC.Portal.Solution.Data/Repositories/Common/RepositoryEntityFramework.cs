using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Notification.Validation.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Data.Repositories.Common
{
    public class RepositoryEntityFramework<TEntity, TIdentifier> : IValidation, IDisposable, 
        IRepository<TEntity, TIdentifier> where TEntity : class, IValidation
    {
        public INotificationContext Notification => throw new NotImplementedException();

        public ValidationResult Validation => throw new NotImplementedException();

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

        public bool IsValid()
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

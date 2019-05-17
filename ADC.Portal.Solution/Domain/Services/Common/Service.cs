using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Services.Common;
using ADC.Portal.Solution.Notification.Validation;
using ADC.Portal.Solution.Notification.Validation.Interface;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Services.Common
{
    public class Service<TEntity, TIdentifier> 
        : ServiceBase, IDisposable, IService<TEntity, TIdentifier> where TEntity : class, IValidation
    {
        private readonly IRepository<TEntity, TIdentifier> _repository;

        public Service(IRepository<TEntity, TIdentifier> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            Notification.Clear();
            _repository.Add(entity);
            Validate(_repository);
        }

        public void Remove(TEntity entity)
        {
            Notification.Clear();
            _repository.Remove(entity);
            Validate(_repository);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            Notification.Clear();
            IEnumerable<TEntity> results = _repository.GetAll();
            Validate(_repository);

            return results;
        }

        public TEntity GetById(TIdentifier id)
        {
            Notification.Clear();
            TEntity result = _repository.GetById(id);
            Validate(_repository);

            return result;
        }        

        public void Update(TEntity entity)
        {
            Notification.Clear();
            _repository.Update(entity);
            Validate(_repository);
        }
    }
}

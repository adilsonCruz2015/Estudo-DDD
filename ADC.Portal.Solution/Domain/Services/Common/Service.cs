using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Services.Common;
using ADC.Portal.Solution.Notification.Validation;
using ADC.Portal.Solution.Notification.Validation.Interface;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Services.Common
{
    public class Service<TEntity, TIdentifier> 
        : IDisposable, IService<TEntity, TIdentifier> where TEntity : class
    {
        private readonly IRepository<TEntity, TIdentifier> _repository;

        public INotificationContext Notification { get; }

        public Service(IRepository<TEntity, TIdentifier> repository)
        {
            _repository = repository;
            Notification = new NotificationContext();
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(TIdentifier id)
        {
            return _repository.GetById(id);
        }        

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}

using ADC.Portal.Solution.Application.Interface.Common;
using ADC.Portal.Solution.Domain.Interfaces.Services.Common;
using ADC.Portal.Solution.Notification.Validation.Interface;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Application.Common
{
    public class App<TEntity, TIdentifier> :
        ApplicationBase, IDisposable, IApp<TEntity, TIdentifier> where TEntity : class, IValidation
    {
        private readonly IService<TEntity, TIdentifier> _service;

        public App(IService<TEntity, TIdentifier> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            Notification.Clear();
            _service.Add(entity);
            Validate(_service);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            Notification.Clear();
            IEnumerable<TEntity> results = _service.GetAll();
            Validate(_service);
            return results;
        }

        public TEntity GetById(TIdentifier id)
        {
            Notification.Clear();
            TEntity result = _service.GetById(id);
            Validate(_service);
            return result;
        }

        public void Remove(TEntity entity)
        {
            Notification.Clear();
            _service.Remove(entity);
            Validate(_service);
        }

        public void Update(TEntity entity)
        {
            Notification.Clear();
            _service.Update(entity);
            Validate(_service);
        }
    }
}

using ADC.Portal.Solution.Application.Interface.Common;
using ADC.Portal.Solution.Domain.Interfaces.Services.Common;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Application.Common
{
    public class App<TEntity, TIdentifier> : IDisposable, IApp<TEntity, TIdentifier> where TEntity : class
    {
        private readonly IService<TEntity, TIdentifier> _service;

        public App(IService<TEntity, TIdentifier> service)
        {
            _service = service;
        }


        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public TEntity GetById(TIdentifier id)
        {
            return _service.GetById(id);
        }

        public void Remove(TEntity entity)
        {
            _service.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _service.Update(entity);
        }
    }
}

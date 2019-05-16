using ADC.Portal.Solution.Data.Context.Interface;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Notification.Validation;
using ADC.Portal.Solution.Notification.Validation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADC.Portal.Solution.Data.Repositories.Common
{
    public class RepositoryNHibernate<TEntity, TIdentifier> : RepositoryBase, IDisposable, 
        IRepository<TEntity, TIdentifier> where TEntity : class, IValidation
    {

        public RepositoryNHibernate(IConnection connection)
            : base(connection) { }       

        public virtual void Add(TEntity entity)
        {
            Notification.Clear();
            Connection.Session.Save(entity);
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            Notification.Clear();
            IEnumerable<TEntity> results = Connection.Session.QueryOver<TEntity>().List();

            if(!Equals(results, null) && results.Count().Equals(0))
                Notification.AddNotification("Registro não encontrado", TypeOfMessage.Error);

            return results;
        }

        public virtual TEntity GetById(TIdentifier id)
        {
            Notification.Clear();
            TEntity result = Connection.Session.Get<TEntity>(id);

            if (Equals(result, null))
                Notification.AddNotification("Registro não encontrado", nameof(id), (object)id, TypeOfMessage.Error);

            return result;
        }

        public virtual void Remove(TEntity entity)
        {
            Notification.Clear();
            Connection.Session.Delete(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Notification.Clear();

            if(Validate(entity))
                Connection.Session.Update(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Equals(Connection, null)) return;
            Connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

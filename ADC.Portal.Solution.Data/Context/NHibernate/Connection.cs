using ADC.Portal.Solution.Data.Context.NHibernate.Mappings;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;

namespace ADC.Portal.Solution.Data.Context.NHibernate
{
    public class Connection : IConnection
    {
        public Connection(ISolveConnection solveConnection)
        {
            _solveConnection = solveConnection;
        }

        private ISession _session;
        private readonly ISolveConnection _solveConnection;

        public ISession Session
        {
            get { return _session ?? Open(); }
            private set { _session = value; }

        }

        public void Close()
        {
            if(!Equals(_session, null))
            {
                if (_session.IsOpen)
                    _session.Close();

                _session.Dispose();
                _session = null;
            }
        }

        public void CloseTransition()
        {
            _session.Transaction.Commit();
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        public bool HasSession()
        {
            return !Equals(_session, null);
        }

        public bool HasTransition()
        {
            return _session?.Transaction?.IsActive ?? false;
        }

        public ISession Open()
        {
            if (Equals(_session, null) || _session.IsOpen.Equals(false))
                _session = SessionFactory.OpenSession();

            return _session;
        }

        public void StartTransition()
        {
            _session.Transaction.Begin();
        }

        public void UndoTransition()
        {
            _session.Transaction.Rollback();
        }

        private ISessionFactory SessionWithFluentNHibernate()
        {
            FluentConfiguration _configuration;

            _configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012                
                .ConnectionString(_solveConnection.GetConnection()))
                .Mappings(map => {
                    map.FluentMappings.AddFromAssemblyOf<CategoryMap>();
                });

            return _configuration.BuildSessionFactory();
        }

        private ISessionFactory _sessionFactory;
        private ISessionFactory SessionFactory
        {
            get
            {
                if (Equals(_sessionFactory, null))
                    _sessionFactory = SessionWithFluentNHibernate();

                return _sessionFactory;
            }
        }
    }
}

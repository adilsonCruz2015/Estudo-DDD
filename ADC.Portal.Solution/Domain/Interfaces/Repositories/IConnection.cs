using NHibernate;
using System;

namespace ADC.Portal.Solution.Domain.Interfaces.Repositories
{
    public interface IConnection : IDisposable
    {
        void Close();

        ISession Open();

        bool HasSession();

        bool HasTransition();

        void StartTransition();

        void CloseTransition();

        void UndoTransition();

        ISession Session { get; }
    }
}

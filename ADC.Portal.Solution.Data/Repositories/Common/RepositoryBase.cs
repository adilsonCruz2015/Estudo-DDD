using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Notification.Validation;
using ADC.Portal.Solution.Notification.Validation.Interface;
using FluentValidation.Results;

namespace ADC.Portal.Solution.Data.Repositories.Common
{
    public class RepositoryBase : IValidation
    {
        public RepositoryBase(IConnection connection)
        {
            Connection = connection;
        }

        public bool IsValid() => Notification.IsValid();

        public INotificationContext Notification { get; protected set; } = new NotificationContext();

        public IConnection Connection { get; }

        public ValidationResult Validation { get; private set; }

        protected bool Validate(IValidation validate)
        {
            bool result = validate.IsValid();
            Validation = validate.Validation;
            Notification.AddNotifications(validate.Validation);

            return result;
        }
    }
}

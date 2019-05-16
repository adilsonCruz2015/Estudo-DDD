using ADC.Portal.Solution.Data.Context.Interface;
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

        public INotificationContext Notification { get; }

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

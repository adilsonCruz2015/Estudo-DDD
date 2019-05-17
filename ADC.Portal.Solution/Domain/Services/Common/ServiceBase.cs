using ADC.Portal.Solution.Notification.Validation;
using ADC.Portal.Solution.Notification.Validation.Interface;
using FluentValidation.Results;

namespace ADC.Portal.Solution.Domain.Services.Common
{
    public class ServiceBase : IValidation
    {
        public ValidationResult Validation { get; private set; }

        public INotificationContext Notification { get; protected set; } = new NotificationContext();

        public bool IsValid() => Notification.IsValid();

        protected bool Validate(IValidation validate)
        {
            bool result = validate.IsValid();
            Validation = validate.Validation;
            Notification.AddNotifications(validate.Validation);

            return result;
        }
        
    }
}

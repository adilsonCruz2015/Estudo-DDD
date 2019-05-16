using FluentValidation.Results;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Notification.Validation.Interface
{
    public interface INotificationContext
    {
        IReadOnlyCollection<Notification> Notifications { get; }

        bool HasNotifications { get; }        

        void AddNotification(string message, TypeOfMessage type);

        void AddNotification(string key, string message, string referencia, object valor);

        void AddNotification(string key, string message, string reference, object value, TypeOfMessage type);

        void AddNotification(string message, string reference, object value, TypeOfMessage type);

        void AddNotification(Notification notification);

        void AddNotifications(IReadOnlyCollection<Notification> notifications);

        void AddNotifications(IList<Notification> notifications);

        void AddNotifications(ICollection<Notification> notifications);

        void AddNotifications(ValidationResult validationResult);

        void Clear();

        bool IsValid();
    }
}

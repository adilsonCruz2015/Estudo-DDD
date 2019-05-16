using ADC.Portal.Solution.Notification.Validation.Interface;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ADC.Portal.Solution.Notification.Validation
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            this._notifications = new List<Notification>();
        }

        public void AddNotification(string message, TypeOfMessage type)
        {
            this._notifications.Add(new Notification(message, type));
        }

        public void AddNotification(string key, string message, string reference, object value)
        {
            this._notifications.Add(new Notification(key, message, reference, value));
        }

        public void AddNotification(string key, string message, string reference, object value, TypeOfMessage type)
        {
            this._notifications.Add(new Notification(key, message, reference, value, type));
        }

        public void AddNotification(string message, string reference, TypeOfMessage type)
        {
            this._notifications.Add(new Notification(message, reference, type));
        }

        public void AddNotification(string message, string reference, object value, TypeOfMessage type)
        {
            this._notifications.Add(new Notification(message, reference, value, type));
        }

        public void AddNotification(Notification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotification(error.ErrorCode, 
                                error.ErrorMessage, 
                                error.PropertyName, 
                                error.AttemptedValue, 
                                TypeOfMessage.Error);
        }

        public void Clear() => this._notifications.Clear(); 

        public bool IsValid() => HasMessages(TypeOfMessage.Error);
        
        private bool HasMessages(params TypeOfMessage[] types) => _notifications.Where(x => types.Contains(x.Type.Value)).Take(1).Count().Equals(1);
    }
}

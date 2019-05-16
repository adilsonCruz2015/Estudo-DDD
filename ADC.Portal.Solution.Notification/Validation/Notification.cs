using System;

namespace ADC.Portal.Solution.Notification.Validation
{
    public class Notification
    {
        public Guid Id { get; private set; }

        public string Key { get; }

        public string Message { get; }

        public string Reference { get; }

        public object Value { get; }

        public TypeOfMessage? Type { get; set; }

        public Notification()
        {
            Id = Guid.NewGuid();
        }

        public Notification(string key, 
                            string message, 
                            string reference, 
                            object value)
            :this(key, message, reference, value, null) {  }

        public Notification(string key,
                            string message,
                            string reference,
                            object value,
                            TypeOfMessage? type)
            : this()
        {
            Key = key;
            Message = message;
            Reference = reference;
            Value = value;
            Type = type;
        }

        public Notification(string message, 
                            string reference, 
                            TypeOfMessage type)
            :this(null, message, reference, null, type) {  }

        public Notification(string message,                            
                            TypeOfMessage type)
            : this(null, message, null, null, type) {  }

        public Notification(string message,
                            string reference,
                            object value,
                            TypeOfMessage type)
            : this(null, message, reference, value, type) {  }
    }
}
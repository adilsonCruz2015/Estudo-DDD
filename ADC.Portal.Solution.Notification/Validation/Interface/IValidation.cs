

using FluentValidation.Results;

namespace ADC.Portal.Solution.Notification.Validation.Interface
{
    public interface IValidation
    {
        bool IsValid();

        ValidationResult Validation { get; }
    }
}

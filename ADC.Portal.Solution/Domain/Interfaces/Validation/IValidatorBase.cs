

using FluentValidation.Results;

namespace ADC.Portal.Solution.Domain.Interfaces.Validation
{
    public interface IValidatorBase
    {
        ValidationResult Validation { get; }

        bool IsValid();
    }
}

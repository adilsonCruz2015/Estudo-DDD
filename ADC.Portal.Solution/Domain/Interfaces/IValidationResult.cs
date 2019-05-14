using FluentValidation;
using FluentValidation.Results;

namespace ADC.Portal.Solution.Domain.Interfaces
{
    public interface IValidationResult
    {
        ValidationResult Validation { get; }

        bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator);
    }
}

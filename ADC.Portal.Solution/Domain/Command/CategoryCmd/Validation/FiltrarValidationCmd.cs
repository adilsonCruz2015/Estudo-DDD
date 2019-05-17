using ADC.Portal.Solution.Domain.Command.Common.HelpCmd;
using FluentValidation;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd.Validation
{
    public class FiltrarValidationCmd : AbstractValidator<FilterCmd>
    {
        public FiltrarValidationCmd()
        {
            RuleFor(x => x.Category)
                .NotNull()
                .WithMessage("{PropertyName} não pode ser nulo");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("{PropertyName} não pode ser nulo");

            RuleForEach(x => x.Category).SetValidator(new GuidHelpValidationCmd());
            RuleForEach(x => x.Status).SetValidator(new StatusHelpValidationCmd());
        }
    }
}

using ADC.Portal.Solution.Domain.Command.Common.HelpCmd;
using FluentValidation;

namespace ADC.Portal.Solution.Domain.Command.Common.Validation
{
    public class GuidValidationCmd : AbstractValidator<GuidCmd>
    {
        public GuidValidationCmd()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("{PropertyName} não pode ser nulo");

            RuleForEach(c => c.Id).SetValidator(new GuidHelpValidationCmd());
        }
    }
}

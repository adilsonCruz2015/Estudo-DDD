using ADC.Portal.Solution.Domain.ObjectValue;
using FluentValidation;

namespace ADC.Portal.Solution.Domain.Command.Common.HelpCmd
{
    public class StatusHelpValidationCmd : AbstractValidator<Status>
    {
        public StatusHelpValidationCmd()
        {
            RuleFor(x => x)
                .IsInEnum()
                .WithMessage("{PropertyName} não é um Enum válido!");
        }
    }
}



using FluentValidation;

namespace ADC.Portal.Solution.Domain.Command.Common.Validation
{
    public class GuidValidationCmd : AbstractValidator<GuidCmd>
    {
        public GuidValidationCmd()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser vazia");    
        }
    }
}

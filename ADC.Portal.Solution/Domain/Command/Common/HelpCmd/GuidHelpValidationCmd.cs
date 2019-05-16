using FluentValidation;
using System;

namespace ADC.Portal.Solution.Domain.Command.Common.HelpCmd
{
    public class GuidHelpValidationCmd : AbstractValidator<Guid>
    {
        public GuidHelpValidationCmd()
        {
            RuleFor(x => x.ToString())
                .Matches(@"^[a-z0-9]{8}(-[a-z0-9]{4}){3}-[a-z0-9]{12}$")
                .Matches(@"^[0]{8}(-[0]{4}){3}-[0]{12}$")
                .WithMessage("{PropertyName} contém um valor, '{PropertyValue}', que não é válido!");
        }
    }
}

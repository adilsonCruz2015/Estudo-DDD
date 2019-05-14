using FluentValidation;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd.Validation
{
    public class InsertValidationCmd : AbstractValidator<InsertCmd>
    {
        public InsertValidationCmd()
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .WithMessage("{PropertyName} não pode ser vazio.")
               .NotNull()
               .WithMessage("{PropertyName} não pode ser nulo.")
               .MaximumLength(InsertCmd.NAME_MAXLENGHT)
               .WithMessage("{PropertyName} deve conter no máximo 250 caracteres")
               .MinimumLength(InsertCmd.NAME_MINLENGHT)
               .WithMessage("{PropertyName} deve conter no mínimo 3 caracteres");

            RuleFor(c => c.Description).Custom((value, context) =>
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length < InsertCmd.DESCRIPTION_MINLENGHT)
                        context.AddFailure("{PropertyName} deve conter no mínimo 3 caracteres");


                    if (value.Length > InsertCmd.DESCRIPTION_MAXLENGHT)
                        context.AddFailure("{PropertyName} deve conter no máximo 500 caracteres");
                }
            });
        }
    }
}

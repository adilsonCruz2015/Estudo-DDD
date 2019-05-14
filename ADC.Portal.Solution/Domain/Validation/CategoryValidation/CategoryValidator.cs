using ADC.Portal.Solution.Domain.ObjectValue;
using FluentValidation;

namespace ADC.Portal.Solution.Domain.Validation.CategoryValidation
{
    public class CategoryValidator  : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser vazio.")
                .NotNull()
                .WithMessage("{PropertyName} não pode ser nulo.")
                .MaximumLength(Category.NAME_MAXLENGHT)
                .WithMessage("{PropertyName} deve conter no máximo 250 caracteres")
                .MinimumLength(Category.NAME_MINLENGHT)
                .WithMessage("{PropertyName} deve conter no mínimo 3 caracteres");

            RuleFor(c => c.Description).Custom((value, context) => 
            {
                if(!string.IsNullOrEmpty(value))
                {
                    if (value.Length < Category.DESCRIPTION_MINLENGHT)
                        context.AddFailure("{PropertyName} deve conter no mínimo 3 caracteres");
                    

                    if(value.Length > Category.DESCRIPTION_MAXLENGHT)
                        context.AddFailure("{PropertyName} deve conter no máximo 500 caracteres");
                }
            });

            RuleFor(c => c.Status).IsInEnum();
        }
    }
}

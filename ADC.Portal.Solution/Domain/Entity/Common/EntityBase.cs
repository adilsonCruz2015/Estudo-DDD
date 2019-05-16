using ADC.Portal.Solution.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace ADC.Portal.Solution.Domain.Entity.Common
{
    public abstract class EntityBase : IValidationResult
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedIn { get; set; }

        public DateTime ChangedIn { get; set; }

        public virtual bool Valid { get; private set; }

        public virtual bool Invalid => !Valid;

        public virtual ValidationResult Validation  { get; private set; }        

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            Validation = validator.Validate(model);
            return Valid = Validation.IsValid;
        }        
    }
}

using ADC.Portal.Solution.Domain.Command.CategoryCmd.Validation;
using ADC.Portal.Solution.Domain.Interfaces;
using ADC.Portal.Solution.Domain.Interfaces.Validation;
using ADC.Portal.Solution.Domain.ObjectValue;
using FluentValidation.Results;
using System;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd
{
    public class UpdateCmd 
        : IOperation<Category>, IValidatorBase
    {
        public UpdateCmd() {  }

        public Guid Id { get; set; }

        public  string Name { get; set; }

        public string Description { get; set; }        

        public ValidationResult Validation { get; protected set; }

        public void Apply(ref Category entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }

        public bool IsValid()
        {
            var validator = new UpdateValidationCmd();
            this.Validation = validator.Validate(this);
            return Validation.IsValid;
        }

        public void Undo(ref Category entity)
        {
            entity = null;
        }

        #region Constant

        public const int NAME_MAXLENGHT = 250;
        public const int NAME_MINLENGHT = 3;

        public const int DESCRIPTION_MAXLENGHT = 500;
        public const int DESCRIPTION_MINLENGHT = 3;

        #endregion
    }
}

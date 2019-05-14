using ADC.Portal.Solution.Domain.Command.CategoryCmd.Validation;
using ADC.Portal.Solution.Domain.Interfaces;
using ADC.Portal.Solution.Domain.Interfaces.Validation;
using ADC.Portal.Solution.Domain.ObjectValue;
using FluentValidation.Results;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd
{
    public class InsertCmd : IOperation<Category>, IValidatorBase
    {
        public InsertCmd() {  }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public ValidationResult Validation { get; protected set; }

        public void Apply(ref Category entity)
        {
            entity = new Category(Name)
            {
                Description = Description
            };
        }

        public bool IsValid()
        {
            var validator = new InsertValidationCmd();
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

using ADC.Portal.Solution.Domain.Command.CategoryCmd.Validation;
using ADC.Portal.Solution.Domain.Interfaces.Validation;
using ADC.Portal.Solution.Domain.ObjectValue;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd
{
    public class FilterCmd : Common.FiltrarCmd<FilterCmd>, IValidatorBase
    {
        public FilterCmd()
        {
            Category = new List<Guid>();
            Status = new List<Status>();
        }

        #region Category --------------------------------------

        public IList<Guid> Category { get; set; }

        public FilterCmd AddCategory(Guid valor)
        {
            this.Category.Add(valor);
            return this;
        }
        public FilterCmd AddCategory(Category valor)
        {
            this.Category.Add(valor.Id);
            return this;
        }
        public FilterCmd RemoverCategory(Guid valor)
        {
            this.Category.Remove(valor);
            return this;
        }
        public FilterCmd RemoverCategory(Category valor)
        {
            this.Category.Remove(valor.Id);
            return this;
        }
        public FilterCmd ConcatCategory(IEnumerable<Guid> valores)
        {
            this.Category = this.Category.Concat(valores).ToList();
            return this;
        }
        public FilterCmd ConcatCategory(IEnumerable<Category> valores)
        {
            this.Category = this.Category.Concat(valores.Select(x => x.Id)).ToList();
            return this;
        }
        public FilterCmd ClearCategory()
        {
            this.Category.Clear();
            return this;
        }
        public IEnumerable<Guid> GetCategory()
        {
            return this.Category;
        }

        #endregion

        #region Status --------------------------------------

        public IList<Status> Status { get; set; }

        public FilterCmd AddStatus(Status valor)
        {
            this.Status.Add(valor);
            return this;
        }
        public FilterCmd RemoverStatus(Status valor)
        {
            this.Status.Remove(valor);
            return this;
        }
        public FilterCmd ConcatStatus(IEnumerable<Status> valores)
        {
            this.Status = this.Status.Concat(valores).ToList();
            return this;
        }
        public FilterCmd ClearStatus()
        {
            this.Status.Clear();
            return this;
        }
        public IEnumerable<Status> GetStatus()
        {
            return this.Status;
        }

        #endregion

        public string PerName { get; set; }
        public FilterCmd ToDefiniePerName(string value)
        {
            PerName = value;
            return this;
        }

        public ValidationResult Validation { get; protected set; }

        public bool IsValid()
        {
            var validator = new FiltrarValidationCmd();
            Validation = validator.Validate(this);
            return Validation.IsValid;
        }

        #region Common Filter
        public override FilterCmd SetMax(int value)
        {
            Maximum = value < 1 ? 0 : value;
            return this;
        }

        public override FilterCmd SetPage(int value)
        {
            Page = value < 1 ? 0 : value;
            return this;
        }

        public override FilterCmd SetKeyWord(string value)
        {
            KeyWord = value;
            return this;
        }
        #endregion
    }
}

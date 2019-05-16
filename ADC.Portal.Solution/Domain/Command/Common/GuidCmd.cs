using ADC.Portal.Solution.Domain.Command.Common.Validation;
using ADC.Portal.Solution.Domain.Interfaces.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADC.Portal.Solution.Domain.Command.Common
{
    public class GuidCmd : IValidatorBase
    {
        public GuidCmd()
        {
            Id = new List<Guid>();
        }

        public GuidCmd(Guid id)
            :this()
        {
            Id.Add(id);
        }

        public GuidCmd(IEnumerable<Guid> ids)
            :this()
        {
            Id = ids.ToList();
        }

        public IList<Guid> Id { get; set; }

        public ValidationResult Validation { get; protected set; }

        public bool IsValid()
        {
            var validator = new GuidValidationCmd();
            Validation = validator.Validate(this);
            return Validation.IsValid;
        }
    }
}

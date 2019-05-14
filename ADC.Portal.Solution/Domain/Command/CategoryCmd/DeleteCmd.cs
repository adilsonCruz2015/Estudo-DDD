using ADC.Portal.Solution.Domain.Command.Common;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Command.CategoryCmd
{
    public class DeleteCmd : GuidCmd
    {
        public DeleteCmd() : base() {  }

        public DeleteCmd(IEnumerable<Guid> ids):base(ids) { }
    }
}

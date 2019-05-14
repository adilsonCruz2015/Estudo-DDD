using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.ObjectValue;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        IEnumerable<Category> Filter(FiltrarCmd command);
    }
}

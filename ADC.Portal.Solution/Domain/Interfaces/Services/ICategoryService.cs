using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.Interfaces.Services.Common;
using ADC.Portal.Solution.Domain.ObjectValue;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Domain.Interfaces.Services
{
    public interface ICategoryService : IService<Category, Guid>
    {
        IEnumerable<Category> Filter(FiltrarCmd command);

        Category Insert(InsertCmd command);

        Category Update(UpdateCmd command);

        void Delete(DeleteCmd command);

    }
}

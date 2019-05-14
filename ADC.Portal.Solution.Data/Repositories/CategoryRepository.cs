using ADC.Portal.Solution.Data.Repositories.Common;
using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.ObjectValue;
using System;
using System.Collections.Generic;

namespace ADC.Portal.Solution.Data.Repositories
{
    public class CategoryRepository :
        RepositoryNHibernate<Category, Guid>, ICategoryRepository
    {
        public IEnumerable<Category> Filter(FiltrarCmd command)
        {
            IList<Category> resultado = new List<Category>();

            throw new NotImplementedException();
        }
    }
}

using ADC.Portal.Solution.Data.Repositories.Common;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.ObjectValue;
using System;

namespace ADC.Portal.Solution.Data.Repositories
{
    public class CategoryRepository : 
        RepositoryNHibernate<Category, Guid>, ICategoryRepository
    {
    }
}

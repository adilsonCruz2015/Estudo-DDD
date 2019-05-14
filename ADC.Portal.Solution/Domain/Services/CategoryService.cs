using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Services;
using ADC.Portal.Solution.Domain.ObjectValue;
using ADC.Portal.Solution.Domain.Services.Common;
using System;

namespace ADC.Portal.Solution.Domain.Services
{
    public class CategoryService : Service<Category, Guid>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
            :base(categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
    }
}

using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Services;
using ADC.Portal.Solution.Domain.ObjectValue;
using ADC.Portal.Solution.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Delete(DeleteCmd command)
        {
            if(command.IsValid())
            {
                Category result = GetById(command.Id.FirstOrDefault().Value);
                if (!object.Equals(result, null))
                    _categoryRepository.Remove(result);
            }
        }

        public IEnumerable<Category> Filter(FiltrarCmd command)
        {
            throw new NotImplementedException();
        }

        public Category Insert(InsertCmd command)
        {
            Category result = null;
            if(command.IsValid())
            {
                command.Apply(ref result);
                _categoryRepository.Add(result);
            }

            return result;
        }

        public Category Update(UpdateCmd command)
        {
            Category result = null;
            if(command.IsValid())
            {
                command.Apply(ref result);
                _categoryRepository.Add(result);
            }

            return result;
        }
    }
}

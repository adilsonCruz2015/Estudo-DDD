using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Services;
using ADC.Portal.Solution.Domain.ObjectValue;
using ADC.Portal.Solution.Domain.Services.Common;
using System;
using System.Collections.Generic;

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
            Notification.Clear();

            if (command.IsValid())
            {
                IEnumerable<Category> results = _categoryRepository.Filter(new FilterCmd() { Category = command.Id });

                if (Notification.IsValid())
                    foreach(Category item in results)
                        _categoryRepository.Remove(item);

                if (_categoryRepository.Notification.HasNotifications)
                    Notification.AddNotifications(_categoryRepository.Notification.Notifications);
            }
            else
                Notification.AddNotifications(command.Validation);
        }

        public IEnumerable<Category> Filter(FilterCmd command)
        {
            Notification.Clear();
            IEnumerable<Category> results = new List<Category>();

            if (command.IsValid())
            {
                results = _categoryRepository.Filter(command);

                if (Notification.HasNotifications)
                    Notification.AddNotifications(_categoryRepository.Notification.Notifications);
            }
            else
                Notification.AddNotifications(command.Validation);

            return results;
        }

        public Category Insert(InsertCmd command)
        {
            Category result = null;

            if(command.IsValid())
            {
                command.Apply(ref result);
                _categoryRepository.Add(result);

                if(_categoryRepository.Notification.HasNotifications)
                    Notification.AddNotifications(_categoryRepository.Notification.Notifications);
            }
            else
            {
                command.Undo(ref result);
                Notification.AddNotifications(command.Validation);
            }

            return result;
        }

        public Category Update(UpdateCmd command)
        {
            Category result = null;
            if(command.IsValid())
            {
                result = _categoryRepository.GetById(command.Id);

                if(!_categoryRepository.Notification.HasNotifications)
                {
                    command.Apply(ref result);
                    _categoryRepository.Add(result);
                }

                if(_categoryRepository.Notification.HasNotifications)
                    Notification.AddNotifications(_categoryRepository.Notification.Notifications);
            }
            else
            {
                command.Undo(ref result);
                Notification.AddNotifications(command.Validation);
            }

            return result;
        }
    }
}

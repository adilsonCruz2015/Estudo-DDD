using ADC.Portal.Solution.Domain.Interfaces.Application;
using ADC.Portal.Solution.Domain.ObjectValue;
using ADC.Portal.Solution.Notification.Validation.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADC.Portal.Solution.Application
{
    public class CategoryApp : ICategoryApp
    {
        public INotificationContext Notification => throw new NotImplementedException();

        public ValidationResult Validation => throw new NotImplementedException();

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

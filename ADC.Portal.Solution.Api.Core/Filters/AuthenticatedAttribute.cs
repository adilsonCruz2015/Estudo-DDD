using ADC.Portal.Solution.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleInjector;

namespace ADC.Portal.Solution.Api.Core.Filters
{
    public class AuthenticatedAttribute : AuthorizeAttribute, IFilterMetadata
    {
        private readonly ICategoryApp _categoryApp;
        private readonly Container _container;

        public AuthenticatedAttribute(Container container)
        {
            _container = container;
        }
    }
}

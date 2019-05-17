using ADC.Portal.Solution.Domain.Interfaces.Services;
using ADC.Portal.Solution.Domain.Services;
using SimpleInjector;

namespace ADC.Portal.Solution.IdC.SimpleInjector.Modules
{
    public static class ServiceModule
    {
        public static void Load(Container container)
        {
            container.Register<ICategoryService, CategoryService>();
        }
    }
}

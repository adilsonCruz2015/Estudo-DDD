

using ADC.Portal.Solution.Application;
using ADC.Portal.Solution.Domain.Interfaces.Application;
using SimpleInjector;

namespace ADC.Portal.Solution.IdC.SimpleInjector.Modules
{
    public static class ApplicationModule
    {
        public static void Load(Container container)
        {
            container.Register<ICategoryApp, CategoryApp>();
        }
    }
}

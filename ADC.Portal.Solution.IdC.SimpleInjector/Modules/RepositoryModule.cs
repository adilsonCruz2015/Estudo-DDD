using ADC.Portal.Solution.Data.Repositories;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using SimpleInjector;

namespace ADC.Portal.Solution.IdC.SimpleInjector.Modules
{
    public static class RepositoryModule
    {
        public static void Load(Container container)
        {
            container.Register<ICategoryRepository, CategoryRepository>();
        }
    }
}

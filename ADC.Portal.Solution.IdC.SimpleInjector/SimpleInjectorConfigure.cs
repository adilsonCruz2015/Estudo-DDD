

using SimpleInjector;

namespace ADC.Portal.Solution.IdC.SimpleInjector
{
    public static class SimpleInjectorConfigure
    {
        public static void Load(Container container)
        {
            Modules.ApplicationModule.Load(container);
            Modules.RepositoryModule.Load(container);
            Modules.ServiceModule.Load(container);
        }
    }
}

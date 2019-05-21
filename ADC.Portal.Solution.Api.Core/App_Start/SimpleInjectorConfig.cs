using ADC.Portal.Solution.Api.Core.App_Start.SimpleInjectorCustom;
using ADC.Portal.Solution.IdC.SimpleInjector;
using CommonServiceLocator;
using SimpleInjector;

namespace ADC.Portal.Solution.Api.Core.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Register(Container container)
        {
            SimpleInjectorConfigure.Load(container);

            container.Verify();

            var adapter = new SimpleInjectorServiceLocatorAdapter(container);
            ServiceLocator.SetLocatorProvider(() => adapter);
        }
    }
}

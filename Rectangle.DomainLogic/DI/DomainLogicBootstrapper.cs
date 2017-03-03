using Castle.Windsor;
using Castle.Windsor.Installer;
using Domain.DI;

namespace Rectangle.DomainLogic.DI
{
    public class DomainLogicBootstrapper
    {
        public static IWindsorContainer Init()
        {
            var container = DomainBootstrapper.BootstrapContainer();
            container.Install(FromAssembly.This());
            return container;
        }
    }
}

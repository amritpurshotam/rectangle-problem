using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Domain.DI
{
    public class DomainBootstrapper
    {
        public static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer()
               .Install(FromAssembly.This()
               );
        }
    }
}
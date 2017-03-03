using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Rectangle.DomainLogic.DI;

namespace RectangleProblem.DI
{
    public class WebBootstrapper
    {
        public static IWindsorContainer Init()
        {
            var container = DomainLogicBootstrapper.Init();
            container.Install(FromAssembly.Containing<DomainLogicInstaller>());
            container.Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            return container;
        }
    }
}
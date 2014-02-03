using System.Web.Mvc;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Test2Can.Web.Controllers;

namespace Test2Can.Dependencies {
	public class ControllersInstaller : IWindsorInstaller {
		public void Install(IWindsorContainer container, IConfigurationStore store) {
			container.Register(Classes.FromAssemblyContaining<CustomerController>()
													.BasedOn<IController>()
													.LifestyleTransient());
		}
	}
}

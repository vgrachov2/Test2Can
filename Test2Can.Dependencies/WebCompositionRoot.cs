using System.Web;
using System.Web.Mvc;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Test2Can.Dependencies {
	public class WebCompositionRoot : HttpApplication {
		private IWindsorContainer _container;
		protected void BootstrapContainer() {
			_container = new WindsorContainer().Install(FromAssembly.This());
			ControllerBuilder.Current.SetControllerFactory(new CastleWindsorControllerFactory(_container.Kernel));
		}

		protected void Application_End() {
			_container.Dispose();
		}
	}
}

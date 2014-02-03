using System;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Castle.MicroKernel;

namespace Test2Can.Dependencies {
	public class CastleWindsorControllerFactory : DefaultControllerFactory {
		private readonly IKernel _kernel;

		public CastleWindsorControllerFactory(IKernel kernel) {
			Contract.Requires(kernel != null);

			_kernel = kernel;
		}

		public override void ReleaseController(IController controller) {
			_kernel.ReleaseComponent(controller);
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
			if (controllerType == null) {
				throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
			}

			return (IController)_kernel.Resolve(controllerType);
		}
	}
}

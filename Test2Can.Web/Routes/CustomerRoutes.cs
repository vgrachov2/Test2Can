using System.Web.Mvc;
using System.Web.Routing;

namespace Test2Can.Web.Routes {
	public class CustomerRoutes : IRouteConfig {
		public void RegisterRoutes(RouteCollection routes) {
			routes.MapRoute(
					name: "customer",
					url: string.Empty,
					defaults: new { controller = "Customer", action = "Search" }
			);

			routes.MapRoute(
					name: "country.cities",
					url: "customers/{country}/cities",
					defaults: new { controller = "Customer", action = "Cities" }
			);

			routes.MapRoute(
					name: "customers",
					url: "customers",
					defaults: new { controller = "Customer", action = "Customers" }
			);
		}
	}
}
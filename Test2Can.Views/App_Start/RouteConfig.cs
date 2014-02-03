using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Test2Can.Web.Routes;

namespace BookKeeping.Views {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			new CustomerRoutes().RegisterRoutes(routes);
		}
	}
}
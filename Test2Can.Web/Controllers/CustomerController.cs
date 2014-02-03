using System.Web.Mvc;

using Test2Can.Query.Dto.Customers;
using Test2Can.Query.Queries.Customers;
using Test2Can.Query.Service;
using Test2Can.Web.Models.Customers;

namespace Test2Can.Web.Controllers {
	public class CustomerController : Controller {
		private readonly IQueryService _queryService;

		public CustomerController(IQueryService queryService) {
			_queryService = queryService;
		}
		
		[HttpGet]
		public ActionResult Search() {
			var countries = _queryService.Query(new GetAllCustomerCountries());
			var model = new CustomerSearchIndexModel(countries);
			return View("search", model);
		}

		[HttpGet]
		public ActionResult Cities(string country) {
			if (string.IsNullOrEmpty(country)) {
				return HttpNotFound();
			}
			var cities = _queryService.Query(new GetCitiesByCountry(country));
			return Json(cities, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult Customers(CustomersFilter filter)
		{
				var customers = _queryService.Query(new GetCustomers(filter));
				return Json(customers, JsonRequestBehavior.AllowGet);
		}
	}
}

using System.Collections.Generic;
using System.Linq;

using Test2Can.EFDao.Entity;
using Test2Can.Query.Queries.Customers;
using Test2Can.Query.Service;

namespace Test2Can.EFDao.QueryHandlers.Customers {
		public class GetAllCustomerCountriesHandler : QueryHandler<GetAllCustomerCountries, IEnumerable<string>> {
			private readonly NORTHWNDEntities _entities;

			public GetAllCustomerCountriesHandler(NORTHWNDEntities entities) {
				_entities = entities;
			}

			public override IEnumerable<string> Handle(GetAllCustomerCountries query) {
				return _entities
					.Customers
					.Select(customer => customer.Country)
					.Distinct()
					.ToList();
			}
		}
}

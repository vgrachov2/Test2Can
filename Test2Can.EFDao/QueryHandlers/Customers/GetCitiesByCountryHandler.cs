using System.Collections.Generic;
using System.Linq;

using Test2Can.EFDao.Entity;
using Test2Can.Query.Queries.Customers;
using Test2Can.Query.Service;

namespace Test2Can.EFDao.QueryHandlers.Customers {
		public class GetCitiesByCountryHandler : QueryHandler<GetCitiesByCountry, IEnumerable<string>> {
			private readonly NORTHWNDEntities _entities;

			public GetCitiesByCountryHandler(NORTHWNDEntities entities) {
				_entities = entities;
			}

			public override IEnumerable<string> Handle(GetCitiesByCountry query) {
				return _entities
					.Customers
					.Where(customer => customer.Country == query.Country)
					.Select(customer => customer.City)
					.Distinct()
					.ToList();
			}
		}
}

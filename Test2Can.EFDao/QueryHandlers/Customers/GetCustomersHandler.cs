using System.Linq;

using Test2Can.EFDao.Entity;
using Test2Can.Query.Dto.Customers;
using Test2Can.Query.Queries.Customers;
using Test2Can.EFDao.Extensions;
using Test2Can.Query.Service;

namespace Test2Can.EFDao.QueryHandlers.Customers {
		public class GetCustomersHandler : QueryHandler<GetCustomers, CustomerSearchResult> {
			private readonly NORTHWNDEntities _entities;

			public GetCustomersHandler(NORTHWNDEntities entities) {
				_entities = entities;
			}

			public override CustomerSearchResult Handle(GetCustomers query) {
				var customersQuery = _entities
					.Customers
					.Where(customer => string.IsNullOrEmpty(query.Filter.City)
						|| customer.City == query.Filter.City)
					.Where(customer => string.IsNullOrEmpty(query.Filter.Country)
						|| customer.Country ==query.Filter.Country)
					.Where(customer => string.IsNullOrEmpty(query.Filter.CompanyName)
						|| customer.CompanyName.Contains(query.Filter.CompanyName));

				var total = customersQuery.Count();

				customersQuery = query.Filter.Order != null ?
						customersQuery.OrderBy(query.Filter.Order.Value.ToString()):
						customersQuery.OrderBy(customer => customer.CustomerID);
				var customers = customersQuery
					.Skip(query.Filter.Skip)
					.Take(query.Filter.Take)
					.Select(
						customer =>
							new CustomerProjection{
								CustomerId = customer.CustomerID,
								CompanyName = customer.CompanyName,
								ContractName = customer.ContactName,
								ContractTitle = customer.ContactTitle,
								Address = customer.Address,
								City = customer.City,
								Region = customer.Region,
								PostalCode = customer.PostalCode,
								Country = customer.Country,
								Phone = customer.Phone,
								Fax = customer.Fax
								})
							.ToList();

				return new CustomerSearchResult(customers, total);
			}
		}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Test2Can.Query.Dto.Customers;
using Test2Can.Query.Service;

namespace Test2Can.Query.Queries.Customers {
		[Serializable]
		public class GetCustomers : IQuery<CustomerSearchResult> {
			private readonly CustomersFilter _filter;

			public GetCustomers(CustomersFilter filter) {
				Contract.Requires(filter != null);

				_filter = filter;
			}

			public CustomersFilter Filter {
				get {
					return _filter;
				}
			}
		}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Test2Can.Query.Dto.Customers {
		[Serializable]
		public class CustomerSearchResult {
			private readonly IEnumerable<CustomerProjection> _customers;
			private readonly int _total;

			public CustomerSearchResult(IEnumerable<CustomerProjection> customers, int total) {
				Contract.Requires(customers != null);

				_customers = customers;
				_total = total;
			}

			public int Total {
				get {
					return _total;
				}
			}

			public IEnumerable<CustomerProjection> Customers {
				get {
					return _customers;
				}
			}
		}
}

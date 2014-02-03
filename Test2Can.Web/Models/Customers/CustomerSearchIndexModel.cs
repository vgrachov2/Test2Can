using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Test2Can.Web.Models.Customers {
		public class CustomerSearchIndexModel {
			private readonly IEnumerable<string> _customerCountries;

			public CustomerSearchIndexModel(IEnumerable<string> customerCountries) {
				Contract.Requires(customerCountries != null);
				_customerCountries = customerCountries;
			}

			public IEnumerable<string> CustomerCountries {
				get {
					return _customerCountries;
				}
			}
		}
}

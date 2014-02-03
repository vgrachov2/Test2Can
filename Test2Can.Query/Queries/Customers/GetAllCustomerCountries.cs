using System;
using System.Collections.Generic;

using Test2Can.Query.Service;

namespace Test2Can.Query.Queries.Customers {
		[Serializable]
		public class GetAllCustomerCountries : IQuery<IEnumerable<string>> {
		}
}

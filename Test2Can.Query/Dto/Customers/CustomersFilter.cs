using System;

namespace Test2Can.Query.Dto.Customers {
		[Serializable]
		public class CustomersFilter {
				public string CompanyName { get; set; }

				public string Country { get; set; }

				public string City { get; set; }

				public int Skip { get; set; }

				public int Take { get; set; }

				public CustomerOrderDirection? Order { get; set; }
		}
}

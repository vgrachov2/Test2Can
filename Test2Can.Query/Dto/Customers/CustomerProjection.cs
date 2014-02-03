﻿using System;

namespace Test2Can.Query.Dto.Customers {
		[Serializable]
		public class CustomerProjection {
			public string CustomerId { get; set; }

			public string CompanyName { get; set; }

			public string ContractName { get; set; }

			public string ContractTitle { get; set; }

			public string Address { get; set; }

			public string City { get; set; }

			public string Region { get; set; }

			public string PostalCode { get; set; }

			public string Country { get; set; }

			public string Phone { get; set; }

			public string Fax { get; set; }
		}
}

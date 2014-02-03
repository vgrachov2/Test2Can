using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Test2Can.Query.Service;

namespace Test2Can.Query.Queries.Customers {
		[Serializable]
		public class GetCitiesByCountry : IQuery<IEnumerable<string>> {
			private readonly string _country;

			public GetCitiesByCountry(string country) {
					Contract.Requires(!string.IsNullOrEmpty(country));

				_country = country;
			}

			public string Country {
				get {
					return _country;
				}
			}
		}
}

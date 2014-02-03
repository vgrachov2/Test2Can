using System.Diagnostics.Contracts;

using Test2Can.Query.Service;

namespace Test2Can.Dependencies.Services {
		public class QueryServiceCacheDecorator : IQueryService {
			private readonly IQueryService _underlying;
			private readonly ICacheKeyBuilder _cacheKeyBuilder;
			private readonly ICacheProvider _cacheProvider;

			public QueryServiceCacheDecorator(
				IQueryService underlying,
				ICacheKeyBuilder cacheKeyBuilder,
				ICacheProvider cacheProvider) {
				Contract.Requires(underlying != null);
				Contract.Requires(cacheKeyBuilder != null);
				Contract.Requires(cacheProvider != null);

				_underlying = underlying;
				_cacheKeyBuilder = cacheKeyBuilder;
				_cacheProvider = cacheProvider;
			}

			public TDto Query<TDto>(IQuery<TDto> query) {
				var cacheKey = _cacheKeyBuilder.BuildKey(query);

				if (_cacheProvider.Contains(cacheKey)) {
					return _cacheProvider.Get<TDto>(cacheKey);
				}

				var result = _underlying.Query(query);
				_cacheProvider.Insert(cacheKey, result);
				return result;
			}
		}
}

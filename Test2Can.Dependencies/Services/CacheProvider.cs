using System;
using System.Runtime.Caching;

namespace Test2Can.Dependencies.Services {
	public class CacheProvider : ICacheProvider {
		private readonly ObjectCache _cache;
		public CacheProvider() {
			_cache = MemoryCache.Default;
		}

		public bool Contains(string key) {
			return _cache.Contains(key);
		}

		public TResult Get<TResult>(string key) {
			if (!_cache.Contains(key)) {
				return default(TResult);
			}

			return (TResult)_cache.Get(key);
		}

		public void Insert(string key, object value) {
			_cache.Add(key, value, DateTime.Now.AddDays(1));
		}
	}
}
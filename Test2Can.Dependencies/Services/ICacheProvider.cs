namespace Test2Can.Dependencies.Services {
		public interface ICacheProvider {
			bool Contains(string key);

			TResult Get<TResult>(string key);

			void Insert(string key, object value);
		}
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Test2Can.Dependencies.Services {
	public class CacheKeyBuilder : ICacheKeyBuilder {
		public string BuildKey(object value) {
			if (!value.GetType().IsSerializable) {
				return Guid.NewGuid().ToString();
			}

			using (var stream = new MemoryStream()) {
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, value);
				stream.Flush();
				stream.Position = 0;
				return Convert.ToBase64String(stream.ToArray());
			}
		}
	}
}
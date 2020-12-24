using Newtonsoft.Json;

namespace Discards.Shared.Extensions
{
	public static class JsonExtensions
	{
		public static string ToJsonString<T>(this T source, JsonSerializerSettings jsonSerializerSettings = null)
		{
			if (source == null) return "";

			if (jsonSerializerSettings == null)
				jsonSerializerSettings = new JsonSerializerSettings
				{
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					Formatting = Formatting.Indented
				};

			var sourceSerialized = JsonConvert.SerializeObject(source, jsonSerializerSettings);
			return sourceSerialized;
		}
	}
}
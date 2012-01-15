using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Helper methods designed to deserialize JSON strings into objects.
	/// </summary>
	public static class JsonHelpers
	{
		/// <summary>
		/// Takes a web response's stream and returns it's contents.
		/// </summary>
		/// <param name="response">The web response.</param>
		/// <returns>The entire response, as a string.</returns>
		public static string GetResponseString(this WebResponse response)
		{
			Stream stream = response.GetResponseStream();
			StreamReader reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}

		/// <summary>
		/// Takes a web response and returns it's contents deserialized into a generic entity.
		/// </summary>
		/// <typeparam name="T">The type to deserialize into.</typeparam>
		/// <param name="response">The web response.</param>
		/// <returns>A concrete object instance with the results of deserializing the response string.</returns>
		public static T GetResponseJson<T>(this WebResponse response) where T : class
		{
			return JsonConvert.DeserializeObject<T>(response.GetResponseString());
		}

		/// <summary>
		/// Deserializes a JSON string's contents into a generic entity.
		/// </summary>
		/// <typeparam name="T">The type to deserialize into.</typeparam>
		/// <param name="json">The JSON string.</param>
		/// <returns>A generic entity instance with the results of the deserialization.</returns>
		public static T DeserializeJson<T>(this string json) where T : class
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		/// <summary>
		/// Deserializes a JSON string's contents into a dynamic object.
		/// </summary>
		/// <param name="json">The JSON string.</param>
		/// <returns>The dynamic result of the deserialization.</returns>
		public static dynamic DeserializeJson(this string json)
		{
			return JsonConvert.DeserializeObject(json);
		}
	}
}

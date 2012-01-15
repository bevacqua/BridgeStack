using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BridgeStack.Common
{
	public static class JsonHelpers
	{
		public static string GetResponseString(this WebResponse response)
		{
			Stream stream = response.GetResponseStream();
			StreamReader reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}

		public static T GetResponseJson<T>(this HttpWebResponse response)
		{
			return JsonConvert.DeserializeObject<T>(response.GetResponseString());
		}

		public static T DeserializeJson<T>(this string json)
		{
			return JsonConvert.DeserializeObject<T>(json);
		}

		public static dynamic DeserializeJson(this string json)
		{
			return JsonConvert.DeserializeObject(json);
		}
	}
}

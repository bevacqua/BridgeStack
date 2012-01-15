using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.Common
{
	public class UnixDateTimeConverter : DateTimeConverterBase
	{
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			long result;
			if (value is DateTime)
			{
				result = ((DateTime)value).ToUnixTime();
			}
			else
			{
				throw new ArgumentException("Date object value expected");
			}
			writer.WriteValue(result);
		}

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name = "reader">The <see cref = "JsonReader" /> to read from.</param>
		/// <param name = "objectType">Type of the object.</param>
		/// <param name = "existing">The existing value of object being read.</param>
		/// <param name = "serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existing, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Integer)
			{
				throw new ArgumentException("Integer token type expected");
			}
			long ticks = (long)reader.Value;
			return ticks.FromUnixTime();
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Utility class for non-extension helper methods.
	/// </summary>
	public static class Utility
	{
		/// <summary>
		/// The JSON MIME type used in content encoding for the StackExchange API protocol.
		/// </summary>
		public static readonly string JsonMimeType = Shared.JsonMimeType;

		/// <summary>
		/// List and return the properties of an object through Reflection.
		/// </summary>
		/// <param name="entity">The object.</param>
		/// <returns>A list of <seealso cref="PropertyInfo"/> properties.</returns>
		public static IEnumerable<PropertyInfo> GetAllProperiesOfObject(object entity)
		{
			const BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;
			PropertyInfo[] list = entity.GetType().GetProperties(flags);

			return list;
		}

		/// <summary>
		/// Concatenates serialized query string parameter lists.
		/// </summary>
		/// <param name="parameters">The serialized query string parameters to concatenate.</param>
		/// <returns>The resulting string.</returns>
		public static string JoinQueryStringParameters(params string[] parameters)
		{
			IList<string> query = parameters.Where(p => !p.NullOrEmpty()).ToList();
			if (!query.Any())
			{
				return string.Empty;
			}
			string result = string.Concat("?", string.Join("&", query));
			return result;
		}

		/// <summary>
		/// Returns a plain JSON object out of query string parameters.
		/// </summary>
		/// <param name="query">The query string.</param>
		/// <returns>The json object.</returns>
		public static string QueryStringToJson(string query)
		{
			if (query.NullOrEmpty())
				return "{}";
			StringBuilder sb = new StringBuilder();
			string separator = string.Empty;
			string[] parameters = query.Split('&');
			sb.Append("{");
			foreach (string[] pair in parameters.Select(param => param.Split('=')))
			{
				if (pair.Length != 2)
				{
					continue;
				}
				sb.Append(separator);
				string name = pair[0];
				string value = pair[1];
				long test;
				if (long.TryParse(value, out test))
				{
					sb.AppendFormat(EndpointBuilder.JsonKeyValuePairNumeric, name, value);
				}
				else
				{
					sb.AppendFormat(EndpointBuilder.JsonKeyValuePair, name, value);
				}
				separator = ", ";
			}
			sb.Append("}");
			return sb.ToString();
		}
	}
}

using System;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// A name/value pair struct for query string parameters.
	/// </summary>
	public struct QueryParam
	{
		/// <summary>
		/// The parameter name.
		/// </summary>
		public string Name;
		/// <summary>
		/// The parameter value.
		/// </summary>
		public string Value;

		/// <summary>
		/// Creates a query param with the provided name and value.
		/// </summary>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		public QueryParam(string name, string value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Creates a query param with the provided name and value.
		/// </summary>
		/// <param name="name">The parameter name.</param>
		/// <param name="value">The parameter value.</param>
		public QueryParam(string name, object value)
			: this(name, (value ?? string.Empty).ToString())
		{
		}

		/// <summary>
		/// Simplifies the resolution of query string building.
		/// </summary>
		/// <returns>The name/value pair serialized, Url Encoded and ready to use in HTTP requests.</returns>
		public override string ToString()
		{
			if (Name.NullOrEmpty() || Value.NullOrEmpty())
			{
				return string.Empty;
			}
			return "{0}={1}".FormatWith(Name, Uri.EscapeDataString(Value));
		}
	}
}
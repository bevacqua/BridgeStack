using System.Collections.Generic;
using BridgeStack.DataContracts.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Describes a filter on the Stack Exchange API.
	/// <para>https://api.stackexchange.com/docs/types/filter</para>
	/// </summary>
	public interface IFilter
	{
		/// <summary>
		/// The id of the filter.
		/// </summary>
		[JsonProperty("filter")]
		string FilterId { get; set; }
		/// <summary>
		/// The fields included in the filter.
		/// </summary>
		[JsonProperty("included_fields")]
		IList<string> IncludedFields { get; set; }
		/// <summary>
		/// The filter type.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("filter_type")]
		FilterTypeEnum? FilterType { get; set; }
	}
}
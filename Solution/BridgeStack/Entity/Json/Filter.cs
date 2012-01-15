using System.Collections.Generic;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Describes a filter on the Stack Exchange API.
	/// <para>https://api.stackexchange.com/docs/types/filter</para>
	/// </summary>
	public sealed class Filter : IFilter
	{
		/// <summary>
		/// The id of the filter.
		/// </summary>
		public string FilterId { get; set; }

		/// <summary>
		/// The fields included in the filter.
		/// </summary>
		public IList<string> IncludedFields { get; set; }

		/// <summary>
		/// The filter type.
		/// </summary>
		public FilterTypeEnum? FilterType { get; set; }
	}
}
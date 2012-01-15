using System.Collections.Generic;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The query parameters for requests to create new filters.
	/// </summary>
	public sealed class CreateFilterQuery : Query
	{
		/// <summary>
		/// The base filter, if any.
		/// </summary>
		public string Base { get; set; }

		/// <summary>
		/// Set to true to turn the filter unsafe.
		/// </summary>
		public bool? Unsafe { get; set; }

		/// <summary>
		/// Included fields.
		/// </summary>
		public IList<string> Include { get; set; }

		/// <summary>
		/// Excluded fields.
		/// </summary>
		public IList<string> Exclude { get; set; }
	}
}
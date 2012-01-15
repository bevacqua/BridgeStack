namespace BridgeStack
{
	/// <summary>
	/// Default filters provided by the StackExchange API.
	/// </summary>
	public class FilterEnum
	{
		/// <summary>
		/// Each type documents which fields are returned under the default filter.
		/// </summary>
		public const string Default = "default";
		/// <summary>
		/// Default plus the *.body fields
		/// </summary>
		public const string WithBody = "withbody";
		/// <summary>
		/// Empty filter
		/// </summary>
		public const string None = "none";
		/// <summary>
		/// Includes just .total
		/// </summary>
		public const string Total = "total";
	}
}
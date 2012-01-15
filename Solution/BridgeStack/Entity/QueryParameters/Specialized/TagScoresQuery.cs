using BridgeStack.Entity.Json;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The tag scores query parameters.
	/// </summary>
	public sealed class TagScoresQuery : SimpleQuery
	{
		/// <summary>
		/// The period on which to query.
		/// </summary>
		public QueryPeriodEnum? Period { get; set; }
	}
}
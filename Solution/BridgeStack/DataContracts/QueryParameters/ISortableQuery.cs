namespace BridgeStack.DataContracts
{
	/// <summary>
	/// These queries allow selecting a sort criteria and filter according to ranges.
	/// </summary>
	public interface ISortableQuery
	{
		/// <summary>
		/// The selected sort criteria.
		/// </summary>
		QuerySortEnum? Sort { get; set; }
		/// <summary>
		/// The minimum, based on the sort criteria.
		/// </summary>
		object Min { get; set; }
		/// <summary>
		/// The maximum, based on the sort criteria.
		/// </summary>
		object Max { get; set; }
	}
}
namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Allows filtering in this query.
	/// </summary>
	public interface IFilteredQuery
	{
		/// <summary>
		/// The id of the filter to use.
		/// </summary>
		string Filter { get; set; }
	}
}
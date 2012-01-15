namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Allows the query to be ordered in a particular direction.
	/// </summary>
	public interface IOrderableQuery : IQuery
	{
		/// <summary>
		/// The order direction.
		/// </summary>
		QueryOrderEnum? Order { get; set; }
	}
}
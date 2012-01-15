namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Allows paging parameters.
	/// </summary>
	public interface IPagedQuery : IQuery
	{
		/// <summary>
		/// The requested page.
		/// </summary>
		int? Page { get; set; }
		/// <summary>
		/// The page size.
		/// </summary>
		int? PageSize { get; set; }
	}
}
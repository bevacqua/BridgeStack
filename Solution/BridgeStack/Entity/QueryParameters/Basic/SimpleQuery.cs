using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The simple query parameters class.
	/// </summary>
	public class SimpleQuery : SiteQuery, IPagedQuery
	{
		/// <summary>
		/// The requested page.
		/// </summary>
		public int? Page { get; set; }

		/// <summary>
		/// The page size.
		/// </summary>
		public int? PageSize { get; set; }
	}
}
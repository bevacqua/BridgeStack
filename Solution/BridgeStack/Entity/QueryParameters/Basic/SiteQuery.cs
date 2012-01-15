using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// These queries require a target network site.
	/// </summary>
	public class SiteQuery : Query, ISiteQuery, IFilteredQuery
	{
		/// <summary>
		/// The API site parameter.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// The id of the filter to use.
		/// </summary>
		public string Filter { get; set; }
	}
}
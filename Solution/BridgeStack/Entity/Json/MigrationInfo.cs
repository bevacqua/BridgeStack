using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a question's migration to or from a different site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/migration-info</para>
	/// </summary>
	public sealed class MigrationInfo : IMigrationInfo<NetworkSite, NetworkSiteStyling, NetworkSiteRelation>
	{
		/// <summary>
		/// The id of the question on the other site.
		/// </summary>
		public long? QuestionId { get; set; }

		/// <summary>
		/// The migration date.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// The other site.
		/// </summary>
		public NetworkSite OtherSite { get; set; }
	}
}
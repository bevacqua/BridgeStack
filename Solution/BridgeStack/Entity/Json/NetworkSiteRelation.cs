using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a site that is related in some way to another site.
	/// <para>https://api.stackexchange.com/docs/types/related-site</para>
	/// </summary>
	public sealed class NetworkSiteRelation : INetworkSiteRelation
	{
		/// <summary>
		/// The name of the site.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A link to the site.
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// How this site is related.
		/// </summary>
		public SiteRelationEnum? Relation { get; set; }
	}
}
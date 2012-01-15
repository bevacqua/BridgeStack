using System;
using System.Collections.Generic;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/site</para>
	/// </summary>
	public sealed class NetworkSite : INetworkSite<NetworkSiteStyling, NetworkSiteRelation>
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
		/// The type of site.
		/// </summary>
		public SiteTypeEnum? SiteType { get; set; }

		/// <summary>
		/// A direct link to the logo of the site.
		/// </summary>
		public string LogoUrl { get; set; }

		/// <summary>
		/// A string used to identify a site in the API.
		/// </summary>
		public string ApiSiteParameter { get; set; }

		/// <summary>
		/// Target audience description for this site.
		/// </summary>
		public string Audience { get; set; }

		/// <summary>
		/// A direct link to the icon of the site.
		/// </summary>
		public string IconUrl { get; set; }

		/// <summary>
		/// A list of Uri aliases for this site.
		/// </summary>
		public IList<string> Aliases { get; set; }

		/// <summary>
		/// The current state of the site.
		/// </summary>
		public SiteStateEnum? SiteState { get; set; }

		/// <summary>
		/// The styling for this site.
		/// </summary>
		public NetworkSiteStyling Styling { get; set; }

		/// <summary>
		/// The date this site was launched.
		/// </summary>
		public DateTime? LaunchDate { get; set; }

		/// <summary>
		/// The date this site started its closed beta.
		/// </summary>
		public DateTime? ClosedBetaDate { get; set; }

		/// <summary>
		/// The date this site started its open beta.
		/// </summary>
		public DateTime? OpenBetaDate { get; set; }

		/// <summary>
		/// A direct link to the favicon of the site.
		/// </summary>
		public string FaviconUrl { get; set; }

		/// <summary>
		/// A list of sites related to this one.
		/// </summary>
		public IList<NetworkSiteRelation> RelatedSites { get; set; }

		/// <summary>
		/// A list of markdown plugins used in this site.
		/// </summary>
		public IList<string> MarkdownExtensions { get; set; }

		/// <summary>
		/// The twitter account associated to this site, if any.
		/// </summary>
		public string TwitterAccount { get; set; }
	}
}
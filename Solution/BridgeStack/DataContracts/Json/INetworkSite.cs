using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents a site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/site</para>
	/// </summary>
	/// <typeparam name="TRelation">The concrete type of <see cref="INetworkSiteRelation"/>.</typeparam>
	/// <typeparam name="TStyling">The concrete type of <see cref="INetworkSiteStyling"/>.</typeparam>
	public interface INetworkSite<TStyling, TRelation>
		where TRelation : INetworkSiteRelation
		where TStyling : INetworkSiteStyling
	{
		/// <summary>
		/// The name of the site.
		/// </summary>
		[JsonProperty("name")]
		string Name { get; set; }
		/// <summary>
		/// A link to the site.
		/// </summary>
		[JsonProperty("site_url")]
		string Link { get; set; }
		/// <summary>
		/// The type of site.
		/// </summary>
		[JsonProperty("site_type")]
		SiteTypeEnum? SiteType { get; set; }
		/// <summary>
		/// A direct link to the logo of the site.
		/// </summary>
		[JsonProperty("logo_url")]
		string LogoUrl { get; set; }
		/// <summary>
		/// A string used to identify a site in the API.
		/// </summary>
		[JsonProperty("api_site_parameter")]
		string ApiSiteParameter { get; set; }
		/// <summary>
		/// Target audience description for this site.
		/// </summary>
		[JsonProperty("audience")]
		string Audience { get; set; }
		/// <summary>
		/// A direct link to the icon of the site.
		/// </summary>
		[JsonProperty("icon_url")]
		string IconUrl { get; set; }
		/// <summary>
		/// A list of Uri aliases for this site.
		/// </summary>
		[JsonProperty("aliases")]
		IList<string> Aliases { get; set; }
		/// <summary>
		/// The current state of the site.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("site_state")]
		SiteStateEnum? SiteState { get; set; }
		/// <summary>
		/// The styling for this site.
		/// </summary>
		[JsonProperty("styling")]
		TStyling Styling { get; set; }
		/// <summary>
		/// The date this site was launched.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("launch_date")]
		DateTime? LaunchDate { get; set; }
		/// <summary>
		/// The date this site started its closed beta.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("closed_beta_date")]
		DateTime? ClosedBetaDate { get; set; }
		/// <summary>
		/// The date this site started its open beta.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("open_beta_date")]
		DateTime? OpenBetaDate { get; set; }
		/// <summary>
		/// A direct link to the favicon of the site.
		/// </summary>
		[JsonProperty("favicon_url")]
		string FaviconUrl { get; set; }
		/// <summary>
		/// A list of sites related to this one.
		/// </summary>
		[JsonProperty("related_sites")]
		IList<TRelation> RelatedSites { get; set; }
		/// <summary>
		/// A list of markdown plugins used in this site.
		/// </summary>
		[JsonProperty("markdown_extensions")]
		IList<string> MarkdownExtensions { get; set; }
		/// <summary>
		/// The twitter account associated to this site, if any.
		/// </summary>
		[JsonProperty("twitter_account")]
		string TwitterAccount { get; set; }
	}
}
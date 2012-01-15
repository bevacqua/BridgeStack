using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents a site that is related in some way to another site.
	/// <para>https://api.stackexchange.com/docs/types/related-site</para>
	/// </summary>
	public interface INetworkSiteRelation
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
		/// How this site is related.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("relation")]
		SiteRelationEnum? Relation { get; set; }
	}
}
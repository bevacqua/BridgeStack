using System;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a question's migration to or from a different site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/migration-info</para>
	/// </summary>
	/// <typeparam name="TSite">The concrete type of <see cref="INetworkSite{TStyling,TRelation}"/>.</typeparam>
	/// /// <typeparam name="TStyling">The concrete type of <see cref="INetworkSiteStyling"/>.</typeparam>
	/// <typeparam name="TRelation">The concrete type of <see cref="INetworkSiteRelation"/>.</typeparam>
	public interface IMigrationInfo<TSite, TStyling, TRelation>
		where TSite : INetworkSite<TStyling, TRelation>
		where TStyling : INetworkSiteStyling
		where TRelation : INetworkSiteRelation
	{
		/// <summary>
		/// The id of the question on the other site.
		/// </summary>
		[JsonProperty("question_id")]
		long? QuestionId { get; set; }
		/// <summary>
		/// The migration date.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("on_date")]
		DateTime? Date { get; set; }
		/// <summary>
		/// The other site.
		/// </summary>
		[JsonProperty("other_site")]
		TSite OtherSite { get; set; }
	}
}
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents an event that has recently occurred on the system.
	/// <para>https://api.stackexchange.com/docs/types/event</para>
	/// </summary>
	public interface IEvent
	{
		/// <summary>
		/// The type of event that occurred.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("event_type")]
		EventTypeEnum? EventType { get; set; }
		/// <summary>
		/// The id of the event.
		/// </summary>
		[JsonProperty("event_id")]
		long? EventId { get; set; }
		/// <summary>
		/// The date the event took place.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// An excerpt of the event.
		/// </summary>
		[JsonProperty("excerpt")]
		string Excerpt { get; set; }
		/// <summary>
		/// A link to the source of the event.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}
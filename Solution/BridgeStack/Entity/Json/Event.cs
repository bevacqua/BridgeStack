using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents an event that has recently occurred on the system.
	/// <para>https://api.stackexchange.com/docs/types/event</para>
	/// </summary>
	public sealed class Event : IEvent
	{
		/// <summary>
		/// The type of event that occurred.
		/// </summary>
		public EventTypeEnum? EventType { get; set; }

		/// <summary>
		/// The id of the event.
		/// </summary>
		public long? EventId { get; set; }

		/// <summary>
		/// The date the event took place.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// An excerpt of the event.
		/// </summary>
		public string Excerpt { get; set; }

		/// <summary>
		/// A link to the source of the event.
		/// </summary>
		public string Link { get; set; }
	}
}
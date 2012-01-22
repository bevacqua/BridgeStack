using System;

namespace BridgeStack
{
	/// <summary>
	/// Event log delegate arguments.
	/// </summary>
	public interface IEventLoggedArgs
	{
		/// <summary>
		/// The severity of the event being logged.
		/// </summary>
		EventSeverityEnum Severity { get; }
		/// <summary>
		/// The message to relay.
		/// </summary>
		string Message { get; }
		/// <summary>
		/// The exception to relay, if any.
		/// </summary>
		Exception Exception { get; }
	}
}
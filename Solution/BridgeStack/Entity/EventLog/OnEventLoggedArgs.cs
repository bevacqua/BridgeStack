using System;

namespace BridgeStack
{
	/// <summary>
	/// Event log delegate arguments.
	/// </summary>
	internal class OnEventLoggedArgs : EventArgs, IEventLoggedArgs
	{
		/// <summary>
		/// The severity of the event being logged.
		/// </summary>
		public EventSeverityEnum Severity { get; set; }
		/// <summary>
		/// The message to relay.
		/// </summary>
		public string Message { get; private set; }
		/// <summary>
		/// The exception to relay, if any.
		/// </summary>
		public Exception Exception { get; private set; }

		/// <summary>
		/// Default arguments constructor with a message to relay.
		/// </summary>
		/// <param name="message">The message to relay.</param>
		public OnEventLoggedArgs(string message)
		{
			Message = message;
		}

		/// <summary>
		/// Arguments constructor with a message and an exception to relay.
		/// </summary>
		/// <param name="message">The message to relay.</param>
		/// <param name="e">The exception to relay</param>
		public OnEventLoggedArgs(string message, Exception e)
			: this(message)
		{
			Exception = e;
		}
	}
}
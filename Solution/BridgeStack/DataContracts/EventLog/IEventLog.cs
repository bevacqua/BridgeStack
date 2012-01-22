namespace BridgeStack
{
	/// <summary>
	/// Event log message dispatcher contract.
	/// </summary>
	public interface IEventLog : IStackClientPlugin
	{
		/// <summary>
		/// Event raised every time an event is registered on the event log.
		/// </summary>
		event OnEventLogged OnEventLogged;

		/// <summary>
		/// Registers a DEBUG message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		void Debug(string message);

		/// <summary>
		/// Registers a DEBUG message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		void DebugFormat(string message, params string[] args);

		/// <summary>
		/// Registers an INFO message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		void Info(string message);

		/// <summary>
		/// Registers an INFO message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		void InfoFormat(string message, params string[] args);

		/// <summary>
		/// Registers a WARNING message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		void Warn(string message);

		/// <summary>
		/// Registers a WARN message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		void WarnFormat(string message, params string[] args);

		/// <summary>
		/// Registers an ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		void Error(string message);

		/// <summary>
		/// Registers an ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		void ErrorFormat(string message, params string[] args);

		/// <summary>
		/// Registers a FATAL ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		void Fatal(string message);

		/// <summary>
		/// Registers a FATAL ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		void FatalFormat(string message, params string[] args);
	}
}
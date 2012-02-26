namespace BridgeStack
{
	/// <summary>
	/// Event log message dispatcher implementation.
	/// </summary>
	internal sealed class EventLog : IEventLog
	{
		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// Event raised every time an event is registered on the event log.
		/// </summary>
		public event OnEventLogged OnEventLogged;

		/// <summary>
		/// Registers a DEBUG message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Debug(string message)
		{
			OnEventLoggedArgs args = new OnEventLoggedArgs(message) { Severity = EventSeverityEnum.Debug };
			InvokeEventLogged(args);
		}

		/// <summary>
		/// Registers a DEBUG message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		public void DebugFormat(string message, params string[] args)
		{
			Debug(string.Format(message, args));
		}

		/// <summary>
		/// Registers an INFO message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Info(string message)
		{
			OnEventLoggedArgs args = new OnEventLoggedArgs(message) { Severity = EventSeverityEnum.Info };
			InvokeEventLogged(args);
		}

		/// <summary>
		/// Registers an INFO message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		public void InfoFormat(string message, params string[] args)
		{
			Info(string.Format(message, args));
		}

		/// <summary>
		/// Registers a WARNING message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Warn(string message)
		{
			OnEventLoggedArgs args = new OnEventLoggedArgs(message) { Severity = EventSeverityEnum.Warning };
			InvokeEventLogged(args);
		}

		/// <summary>
		/// Registers a WARN message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		public void WarnFormat(string message, params string[] args)
		{
			Warn(string.Format(message, args));
		}

		/// <summary>
		/// Registers an ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Error(string message)
		{
			OnEventLoggedArgs args = new OnEventLoggedArgs(message) { Severity = EventSeverityEnum.Error };
			InvokeEventLogged(args);
		}

		/// <summary>
		/// Registers an ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		public void ErrorFormat(string message, params string[] args)
		{
			Error(string.Format(message, args));
		}

		/// <summary>
		/// Registers a FATAL ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		public void Fatal(string message)
		{
			OnEventLoggedArgs args = new OnEventLoggedArgs(message) { Severity = EventSeverityEnum.Fatal };
			InvokeEventLogged(args);
		}

		/// <summary>
		/// Registers a FATAL ERROR message to be propagated through all hooked event delegates.
		/// </summary>
		/// <param name="message">The message to be logged.</param>
		/// <param name="args">The arguments for the message format.</param>
		public void FatalFormat(string message, params string[] args)
		{
			Fatal(string.Format(message, args));
		}

		/// <summary>
		/// Invokes <see cref="OnEventLogged"/> on all associated event delegates.
		/// </summary>
		/// <param name="args">The event arguments.</param>
		internal void InvokeEventLogged(OnEventLoggedArgs args)
		{
			if (OnEventLogged != null)
				OnEventLogged(Client, args);
		}
	}
}
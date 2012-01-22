using System;

namespace BridgeStack
{
	/// <summary>
	/// Stack Client plugin container.
	/// </summary>
	internal class StackClientPlugins
	{
		/// <summary>
		/// The default values for this client.
		/// </summary>
		public IDefaults Default { get; protected internal set; }

		/// <summary>
		/// Event log message dispatcher.
		/// </summary>
		public IEventLog EventLog { get; protected internal set; }

		/// <summary>
		/// Request handler.
		/// </summary>
		public IRequestHandler RequestHandler { get; protected internal set; }

		/// <summary>
		/// API Response cache store.
		/// </summary>
		public IResponseCache Cache { get; protected internal set; }

		/// <summary>
		/// Request throttler.
		/// </summary>
		public IRequestThrottler Throttler { get; protected internal set; }

		/// <summary>
		/// Instance a new Stack Client plugin container.
		/// </summary>
		/// <param name="defaults">Defaults values for queries executed against this client.</param>
		/// <param name="handler">A request handler for this client.</param>
		/// <param name="logger">Event log message dispatcher.</param>
		/// <param name="cache">API Response cache store.</param>
		/// <param name="throttler">Request throttler.</param>
		public StackClientPlugins(IDefaults defaults, IRequestHandler handler, IEventLog logger, IResponseCache cache, IRequestThrottler throttler)
		{
			if (defaults == null)
			{
				throw new ArgumentNullException("defaults");
			}
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			if (cache == null)
			{
				throw new ArgumentNullException("cache");
			}
			if (throttler == null)
			{
				throw new ArgumentNullException("throttler");
			}
			Default = defaults;
			RequestHandler = handler;
			EventLog = logger;
			Cache = cache;
			Throttler = throttler;
		}
	}
}
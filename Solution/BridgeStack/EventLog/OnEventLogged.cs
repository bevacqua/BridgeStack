namespace BridgeStack
{
	/// <summary>
	/// Delegate executed when an event is registered on the event log.
	/// </summary>
	/// <param name="sender">The invoking <see cref="IStackClient"/>.</param>
	/// <param name="args">The event arguments.</param>
	public delegate void OnEventLogged(object sender, IEventLoggedArgs args);
}
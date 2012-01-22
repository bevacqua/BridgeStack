namespace BridgeStack
{
	/// <summary>
	/// Indicates this implementation is coupled to a StackClient.
	/// </summary>
	public interface IStackClientPlugin
	{
		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		IStackClient Client { get; set; }
	}
}
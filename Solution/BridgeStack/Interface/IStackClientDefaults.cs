namespace BridgeStack
{
	/// <summary>
	/// Default values for queries coming from a particular client instance.
	/// </summary>
	public interface IStackClientDefaults
	{
		/// <summary>
		/// Default filter for all requests.
		/// </summary>
		string Filter { get; set; }
		/// <summary>
		/// Default page size for all requests.
		/// </summary>
		int? PageSize { get; set; }
		/// <summary>
		/// Default target network site for all requests.
		/// </summary>
		string Site { get; set; }
	}
}
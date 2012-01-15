namespace BridgeStack.DataContracts
{
	/// <summary>
	/// These queries require a target network site.
	/// </summary>
	public interface ISiteQuery : IQuery
	{
		/// <summary>
		/// The API site parameter.
		/// </summary>
		[RequiredParameter]
		string Site { get; set; }
	}
}
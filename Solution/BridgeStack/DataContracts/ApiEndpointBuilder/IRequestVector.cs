namespace BridgeStack
{
	/// <summary>
	/// A request vector is tasked with parsing lists of elements when building an endpoint.
	/// </summary>
	public interface IRequestVector
	{
		/// <summary>
		/// When this property is accessed, the request vector should be processed and it's result presented.
		/// </summary>
		QueryParam Result { get; }
	}
}
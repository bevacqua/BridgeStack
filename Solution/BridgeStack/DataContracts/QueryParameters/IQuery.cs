namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Query string parameters inherit from here.
	/// </summary>
	public interface IQuery
	{
		/// <summary>
		/// Creates a copy of this query object instance, including parameter values.
		/// </summary>
		/// <returns>The created copy.</returns>
		IQuery ShallowCopy();
	}
}
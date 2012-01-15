using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Base query class.
	/// </summary>
	public abstract class Query : IQuery
	{
		/// <summary>
		/// Creates a copy of this query object instance, including parameter values.
		/// </summary>
		/// <returns>The created copy.</returns>
		public IQuery ShallowCopy()
		{
			return (IQuery)MemberwiseClone();
		}
	}
}
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a privilege a user may have on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/privilege</para>
	/// </summary>
	public sealed class Privilege : IPrivilege
	{
		/// <summary>
		/// A short description for this privilege.
		/// </summary>
		public string ShortDescription { get; set; }

		/// <summary>
		/// The full description for this privilege.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Reputation score necessary to earn this privilege.
		/// </summary>
		public long? Reputation { get; set; }
	}
}
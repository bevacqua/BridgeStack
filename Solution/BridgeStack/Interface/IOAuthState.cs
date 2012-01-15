using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// OAuth state parameters contract.
	/// </summary>
	public interface IOAuthState : IDictionary<string, string>
	{
	}
}
using System;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Indicates that at least one property with this attribute must be set, otherwise the API will raise an exception.
	/// This is verified during query string parsing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredParameterOrAttribute : Attribute
	{
	}
}
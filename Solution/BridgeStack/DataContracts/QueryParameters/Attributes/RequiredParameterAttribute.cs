using System;

namespace BridgeStack
{
	/// <summary>
	/// Indicates that this property must be set, otherwise the API will raise an exception.
	/// This is verified during query string parsing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredParameterAttribute : Attribute
	{
	}
}
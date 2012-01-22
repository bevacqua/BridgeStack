using System;
using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Enum extensions.
	/// </summary>
	internal static class EnumHelpers
	{
		/// <summary>
		/// Checks for a <see cref="EnumMemberAttribute"/> decorating the value, and returns the actual string value for the provided member.
		/// </summary>
		/// <param name="member">The enum member.</param>
		/// <returns>The actual enum string value.</returns>
		public static string GetValue(this Enum member)
		{
			EnumMemberAttribute attribute = member.GetCustomAttribute<EnumMemberAttribute>();
			if (attribute != null && !attribute.Value.NullOrEmpty())
			{
				return attribute.Value;
			}
			return Enum.GetName(member.GetType(), member);
		}
	}
}

using System;
using System.Linq;
using System.Reflection;

namespace BridgeStack
{
	/// <summary>
	/// Reflection helpers to help deal with attributes.
	/// </summary>
	internal static class AttributeHelpers
	{
		/// <summary>
		/// Returns the first occurrence of a given attribute T on a property.
		/// </summary>
		/// <typeparam name="T">The type of the attribute to look for.</typeparam>
		/// <param name="prop">The property info instance.</param>
		/// <returns>The attribute instance on the target, if any.</returns>
		public static T GetCustomAttribute<T>(this PropertyInfo prop) where T : Attribute
		{
			return prop.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
		}

		/// <summary>
		/// Returns the first occurrence of a given attribute T on a member.
		/// </summary>
		/// <typeparam name="T">The type of the attribute to look for.</typeparam>
		/// <param name="member">The member info instance.</param>
		/// <returns>The attribute instance on the target, if any.</returns>
		public static T GetCustomAttribute<T>(this MemberInfo member) where T : Attribute
		{
			return member.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
		}

		/// <summary>
		/// Returns the first occurrence of a given attribute T on an Enum value.
		/// </summary>
		/// <typeparam name="T">The type of the attribute to look for.</typeparam>
		/// <param name="value">The enum instance.</param>
		/// <returns>The attribute instance on the target, if any.</returns>
		public static T GetCustomAttribute<T>(this Enum value) where T : Attribute
		{
			Type type = value.GetType();
			MemberInfo[] member = type.GetMember(Enum.GetName(type, value));
			return member[0].GetCustomAttribute<T>();
		}
	}
}

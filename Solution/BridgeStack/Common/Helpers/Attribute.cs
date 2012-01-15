using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BridgeStack.Common
{
	public static class AttributeHelpers
	{
		public static IEnumerable<T> GetCustomAttributes<T>(this PropertyInfo prop) where T : Attribute
		{
			return prop.GetCustomAttributes(typeof(T), true).Cast<T>();
		}

		public static T GetCustomAttribute<T>(this PropertyInfo prop) where T : Attribute
		{
			return prop.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
		}

		public static T GetCustomAttribute<T>(this MemberInfo info) where T : Attribute
		{
			return info.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
		}

		public static T GetCustomAttribute<T>(this Enum value) where T : Attribute
		{
			Type type = value.GetType();
			MemberInfo[] member = type.GetMember(Enum.GetName(type, value));
			return member[0].GetCustomAttribute<T>();
		}
	}
}

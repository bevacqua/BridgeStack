using System;
using System.Collections.Generic;
using System.Reflection;

namespace BridgeStack.Common
{
	public static class Utility
	{
		public const string JsonMimeType = "application/json; charset=utf-8";

		public static IEnumerable<PropertyInfo> GetAllProperiesOfObject(object o)
		{
			const BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance;
			PropertyInfo[] list = o.GetType().GetProperties(flags);

			return list;
		}
	}
}

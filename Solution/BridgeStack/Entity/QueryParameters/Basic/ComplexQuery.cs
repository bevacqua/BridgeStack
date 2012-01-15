using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The complex query parameters class.
	/// </summary>
	public abstract class ComplexQuery : RangedQuery, ISortableQuery, IOrderableQuery
	{
		/// <summary>
		/// The selected sort criteria.
		/// </summary>
		public abstract QuerySortEnum? Sort { get; set; }

		/// <summary>
		/// The minimum, based on the sort criteria.
		/// </summary>
		public object Min { get; set; }

		/// <summary>
		/// The maximum, based on the sort criteria.
		/// </summary>
		public object Max { get; set; }

		/// <summary>
		/// The order direction.
		/// </summary>
		public QueryOrderEnum? Order { get; set; }

		/// <summary>
		/// Returns a list of allowed <see cref="QuerySortEnum"/> values for this particular query.
		/// </summary>
		/// <returns>An enumeration of allowed <see cref="QuerySortEnum"/> values.</returns>
		public IEnumerable<QuerySortEnum> GetAllowedSortValues()
		{
			Type type = GetType();
			PropertyInfo prop = type.GetProperty("Sort");
			AllowedSortValuesAttribute attribute = prop.GetCustomAttribute<AllowedSortValuesAttribute>();
			if (attribute == null)
			{
				return Enumerable.Empty<QuerySortEnum>();
			}
			return attribute.Values;
		}
	}
}
using System;
using BridgeStack.DataContracts;

namespace BridgeStack
{
	/// <summary>
	/// Extension methods for the IQuery interface.
	/// </summary>
	public static class QueryHelpers
	{
		/// <summary>
		/// Updates query string parameters with defaults values, if not overridden.
		/// </summary>
		/// <param name="query">The query string parameters object.</param>
		/// <param name="defaults">The client defaults.</param>
		/// <returns>The query string parameters with default values applied.</returns>
		public static IQuery WithDefault(this IQuery query, IStackClientDefaults defaults)
		{
			if (query is ISiteQuery)
			{
				((ISiteQuery)query).Site = ((ISiteQuery)query).Site ?? defaults.Site;
			}
			if (query is IPagedQuery)
			{
				((IPagedQuery)query).PageSize = ((IPagedQuery)query).PageSize ?? defaults.PageSize;
			}
			if (query is IFilteredQuery)
			{
				((IFilteredQuery)query).Filter = ((IFilteredQuery)query).Filter ?? defaults.Filter;
			}
			return query;
		}
	}
}

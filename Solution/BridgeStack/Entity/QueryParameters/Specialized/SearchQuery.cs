using System.Collections.Generic;
using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The search query parameters.
	/// </summary>
	public class SearchQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Votes"/> and <see cref="QuerySortEnum.Relevance"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes, QuerySortEnum.Relevance)]
		public override QuerySortEnum? Sort { get; set; }

		/// <summary>
		/// Results must match all tags in the list.
		/// </summary>
		[RequiredParameterOr]
		public IList<string> Tagged { get; set; }

		/// <summary>
		/// Results must match none of the tags in the list.
		/// </summary>
		public IList<string> NotTagged { get; set; }

		/// <summary>
		/// The title search string.
		/// </summary>
		[RequiredParameterOr]
		public string InTitle { get; set; }
	}
}
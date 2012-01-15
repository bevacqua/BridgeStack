using System.Collections.Generic;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The similar search query string parameters.
	/// </summary>
	public class SearchSimilarQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Votes"/> and <see cref="QuerySortEnum.Relevance"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes, QuerySortEnum.Relevance)]
		public override QuerySortEnum? Sort { get; set; }

		/// <summary>
		/// Results must match all tags in the list.
		/// </summary>
		public IList<string> Tagged { get; set; }

		/// <summary>
		/// Results must match none of the tags in the list.
		/// </summary>
		public IList<string> NotTagged { get; set; }

		/// <summary>
		/// The title search string.
		/// </summary>
		[RequiredParameter]
		public string InTitle { get; set; }
	}
}
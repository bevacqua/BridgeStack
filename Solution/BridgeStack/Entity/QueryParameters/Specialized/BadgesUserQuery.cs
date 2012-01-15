using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The badge query parameters.
	/// </summary>
	public class BadgesOnUserQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.BadgeRank"/>, <see cref="QuerySortEnum.Name"/>, <see cref="QuerySortEnum.Name"/>, and <see cref="QuerySortEnum.Awarded"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.BadgeRank, QuerySortEnum.Name, QuerySortEnum.Type, QuerySortEnum.Awarded)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
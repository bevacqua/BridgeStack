using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The badge query parameters.
	/// </summary>
	public class BadgesQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.BadgeRank"/>, <see cref="QuerySortEnum.Name"/>, and <see cref="QuerySortEnum.Type"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.BadgeRank, QuerySortEnum.Name, QuerySortEnum.Type)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
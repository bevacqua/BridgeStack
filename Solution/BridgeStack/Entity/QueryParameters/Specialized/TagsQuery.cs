using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The tags query parameters.
	/// </summary>
	public class TagsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Popular"/> and <see cref="QuerySortEnum.Name"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Popular, QuerySortEnum.Name)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
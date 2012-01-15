using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The question favorites query parameters.
	/// </summary>
	public sealed class QuestionFavoritesQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Votes"/> and <see cref="QuerySortEnum.Added"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes, QuerySortEnum.Added)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
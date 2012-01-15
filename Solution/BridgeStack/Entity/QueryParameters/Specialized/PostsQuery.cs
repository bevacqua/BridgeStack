using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The post query parameters.
	/// </summary>
	public sealed class PostsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, and <see cref="QuerySortEnum.Votes"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
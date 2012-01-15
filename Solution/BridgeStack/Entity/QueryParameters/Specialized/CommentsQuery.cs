using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The post comments query parameters.
	/// </summary>
	public sealed class CommentsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Creation"/>, and <see cref="QuerySortEnum.Votes"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Creation, QuerySortEnum.Votes)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
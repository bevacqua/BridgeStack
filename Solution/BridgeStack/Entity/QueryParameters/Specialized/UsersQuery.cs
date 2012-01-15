using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The user query parameters.
	/// </summary>
	public class UsersQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Modified"/>, <see cref="QuerySortEnum.Name"/> and <see cref="QuerySortEnum.Reputation"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Creation, QuerySortEnum.Modified, QuerySortEnum.Name, QuerySortEnum.Reputation)]
		public override QuerySortEnum? Sort { get; set; }
	}
}
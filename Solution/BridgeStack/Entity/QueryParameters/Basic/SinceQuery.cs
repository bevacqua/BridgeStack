using System;

namespace BridgeStack
{
	/// <summary>
	/// The since query parameters class.
	/// </summary>
	public class SinceQuery : SimpleQuery
	{
		/// <summary>
		/// The start date.
		/// </summary>
		public DateTime? Since { get; set; }
	}
}
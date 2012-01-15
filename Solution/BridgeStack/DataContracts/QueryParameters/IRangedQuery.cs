using System;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// These queries allow to select a date range.
	/// </summary>
	public interface IRangedQuery
	{
		/// <summary>
		/// The date window filter's From date.
		/// </summary>
		DateTime? FromDate { get; set; }
		/// <summary>
		/// The date window filter's To date.
		/// </summary>
		DateTime? ToDate { get; set; }
	}
}
using System;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Common "wrapper" object for BridgeStack exceptions.
	/// </summary>
	public interface IBridgeException
	{
		/// <summary>
		/// Exception details coming from the Stack Exchange API.
		/// </summary>
		IApiException ApiResponse { get; }
		/// <summary>
		/// Message describing the raised exception.
		/// </summary>
		string Message { get; }
		/// <summary>
		/// Actual exception raised, if any.
		/// </summary>
		Exception InnerException { get;  }
		/// <summary>
		/// The stack trace for this exception.
		/// </summary>
		string StackTrace { get; }
	}
}
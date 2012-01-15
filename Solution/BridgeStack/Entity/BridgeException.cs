using System;
using System.Diagnostics;
using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// Wraps an exception thrown by the bridge.
	/// </summary>
	[DebuggerDisplay("{Message}, IsApiException={IsApiException}")]
	public sealed class BridgeException : Exception, IBridgeException
	{
		/// <summary>
		/// Exception details for errors raised by the API.
		/// </summary>
		public IApiException ApiResponse { get; internal set; }

		/// <summary>
		/// If true, this Exception was raised by the API and not by the bridge.
		/// </summary>
		public bool IsApiException
		{
			get { return ApiResponse != null; }
		}

		/// <summary>
		/// Disallow parameterless construction.
		/// </summary>
		private BridgeException()
		{
		}

		/// <summary>
		/// Wraps an exception thrown by the bridge.
		/// </summary>
		/// <param name="message">The error message.</param>
		public BridgeException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Wraps an exception thrown by the bridge.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="e">The exception being wrapped.</param>
		public BridgeException(string message, Exception e)
			: base(message, e)
		{
		}

		/// <summary>
		/// Wraps an exception thrown by the bridge.
		/// </summary>
		/// <param name="message">The error message.</param>
		/// <param name="e">The exception being wrapped.</param>
		/// <param name="details">The API exception details</param>
		public BridgeException(string message, Exception e, IApiException details)
			: this(message, e)
		{
			ApiResponse = details;
		}
	}
}
using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// Exception information coming from the Stack Exchange API.
	/// </summary>
	public sealed class ApiException : IApiException
	{
		/// <summary>
		/// The error id.
		/// </summary>
		public long? ErrorId { get; internal set; }

		/// <summary>
		/// The error message.
		/// </summary>
		public string ErrorMessage { get; internal set; }

		/// <summary>
		/// The error name.
		/// </summary>
		public string ErrorName { get; internal set; }

		/// <summary>
		/// The error description, if any.
		/// </summary>
		public string ErrorDescription { get; internal set; }
	}
}
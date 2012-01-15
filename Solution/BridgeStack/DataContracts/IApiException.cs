using Newtonsoft.Json;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Exception information coming from the Stack Exchange API.
	/// </summary>
	public interface IApiException
	{
		/// <summary>
		/// The error id.
		/// </summary>
		[JsonProperty("error_id")]
		long? ErrorId { get; }
		/// <summary>
		/// The error message.
		/// </summary>
		[JsonProperty("error_message")]
		string ErrorMessage { get; }
		/// <summary>
		/// The error name.
		/// </summary>
		[JsonProperty("error_name")]
		string ErrorName { get; }
		/// <summary>
		/// The error description, if any.
		/// </summary>
		[JsonProperty("description")]
		string ErrorDescription { get; }
	}
}
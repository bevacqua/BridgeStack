using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents the stylings of a site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/styling</para>
	/// </summary>
	public sealed class NetworkSiteStyling : INetworkSiteStyling
	{
		/// <summary>
		/// The color for links.
		/// </summary>
		public string LinkColor { get; set; }

		/// <summary>
		/// Foreground color for tags.
		/// </summary>
		public string TagForegroundColor { get; set; }

		/// <summary>
		/// Background color for tags.
		/// </summary>
		public string TagBackgroundColor { get; set; }
	}
}
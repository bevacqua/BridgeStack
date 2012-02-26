using System;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents the stylings of a site in the Stack Exchange network.
	/// <para>https://api.stackexchange.com/docs/types/styling</para>
	/// </summary>
	public interface INetworkSiteStyling
	{
		/// <summary>
		/// The color for links.
		/// </summary>
		[JsonProperty("link_color")]
		string LinkColor { get; set; }
		/// <summary>
		/// Foreground color for tags.
		/// </summary>
		[JsonProperty("tag_foreground_color")]
		string TagForegroundColor { get; set; }
		/// <summary>
		/// Background color for tags.
		/// </summary>
		[JsonProperty("tag_background_color")]
		string TagBackgroundColor { get; set; }
	}
}
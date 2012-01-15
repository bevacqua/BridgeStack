using System;
using System.Net;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Web client used to handle API compression.
	/// </summary>
	internal sealed class ApiWebClient : WebClient
	{
		/// <summary>
		/// Creates a web request object tuned to handle decompression.
		/// </summary>
		/// <param name="address">The API endpoint.</param>
		/// <returns>Returns the web request object, tuned to handle decompression.</returns>
		protected override WebRequest GetWebRequest(Uri address)
		{
			HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
			request.Accept = "gzip,deflate";
			request.UserAgent = Shared.LibraryName;
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
			request.Timeout = 300 * 1000; // 300 seconds.
			return request;
		}
	}
}
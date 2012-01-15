using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	internal sealed class RequestVectorResult : IRequestVectorResult
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}
}
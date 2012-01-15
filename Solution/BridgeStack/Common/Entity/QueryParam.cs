namespace BridgeStack.Entity
{
	public class QueryParam
	{
		public string Name { get; set; }
		public string Value { get; set; }

		public QueryParam(string name, string value)
		{
			Name = name;
			Value = value;
		}
	}
}
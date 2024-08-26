namespace VP.CodingChallenge.WCNet.Attributes;

internal sealed class CommandKeyAttribute : Attribute
{
	public String Key { get; }

	public CommandKeyAttribute(String key)
	{
		Key = key;
	}
}

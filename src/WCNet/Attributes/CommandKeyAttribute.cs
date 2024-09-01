namespace VP.CodingChallenge.WCNet.Attributes;

internal sealed class CommandKeyAttribute : Attribute
{
	public CommandKey Key { get; }

    public CommandKeyAttribute(String key)
        : this((CommandKey)key)
    {
    }

	public CommandKeyAttribute(CommandKey key)
	{
		Key = key;
	}
}

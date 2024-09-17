namespace VP.CodingChallenge.WCNet.Attributes;

internal sealed class CommandKeyAttribute : Attribute
{
	public Command Key { get; }

    public CommandKeyAttribute(String key)
        : this((Command)key)
    {
    }

	public CommandKeyAttribute(Command key)
	{
		Key = key;
	}
}

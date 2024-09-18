namespace VP.CodingChallenge.WCNet.Attributes;

internal sealed class CommandKeyAttribute : Attribute
{
<<<<<<< HEAD
	public Command Key { get; }

    public CommandKeyAttribute(String key)
        : this((Command)key)
    {
    }

	public CommandKeyAttribute(Command key)
=======
	public CommandKey Key { get; }

    public CommandKeyAttribute(String key)
        : this((CommandKey)key)
    {
    }

	public CommandKeyAttribute(CommandKey key)
>>>>>>> master
	{
		Key = key;
	}
}

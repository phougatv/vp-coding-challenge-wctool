namespace VP.CodingChallenge.WCNet.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class CommandKeyAttribute(Command key) : Attribute
{
    public Command Key { get; } = key;

    public CommandKeyAttribute(String key)
        : this((Command)key)
    {
    }
}
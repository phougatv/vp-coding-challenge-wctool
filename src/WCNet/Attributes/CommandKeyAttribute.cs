namespace VP.CodingChallenge.WCNet.Attributes;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
internal sealed class CommandKeyAttribute(CommandKey key) : Attribute
{
    public CommandKey Key { get; } = key;

    public CommandKeyAttribute(String key)
        : this((CommandKey)key)
    {
    }
}
namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct CommandKey : IEquatable<CommandKey>
{
    public static readonly CommandKey None = "none";

	public String Key { get; }

	public CommandKey(String key)
	{
        ArgumentNullException.ThrowIfNull(key);

        Key = key;
	}

	public Boolean Equals(CommandKey other) => String.Equals(Key, other.Key);
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandKey other && Equals(other);
	public override Int32 GetHashCode() => Key.GetHashCode();
    public override String ToString() => Key;
    public static implicit operator CommandKey(String key) => new CommandKey(key);
    public static implicit operator String(CommandKey commandKey) => commandKey.Key;
    public static Boolean operator ==(CommandKey left, CommandKey right) => left.Equals(right);
    public static Boolean operator !=(CommandKey left, CommandKey right) => !left.Equals(right);
}

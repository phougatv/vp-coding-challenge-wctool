namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct Command : IEquatable<Command>
{
    public static readonly Command None = "none";

	public String Key { get; }

	public Command(String key)
	{
		Key = key;
	}

	public Boolean Equals(Command other) => String.Equals(Key, other.Key);
	public override Boolean Equals(Object? obj) => obj is not null && obj is Command other && Equals(other);
	public override Int32 GetHashCode() => Key.GetHashCode();
    public override String ToString() => Key;
    public static implicit operator Command(String key) => new Command(key);
    public static implicit operator String(Command commandKey) => commandKey.Key;
    public static Boolean operator ==(Command left, Command right) => left.Equals(right);
    public static Boolean operator !=(Command left, Command right) => !left.Equals(right);

    public Boolean IsNone() => IsOrdinalIgnoreCaseComparisonEqual(None);
    public Boolean IsByteCountKey() => IsOrdinalIgnoreCaseComparisonEqual("c");
    public Boolean IsCharacterCountKey() => IsOrdinalIgnoreCaseComparisonEqual("m");
    public Boolean IsLineCountKey() => IsOrdinalIgnoreCaseComparisonEqual("l");
    public Boolean IsWordCountKey() => IsOrdinalIgnoreCaseComparisonEqual("w");

    #region Private Methods
    private Boolean IsOrdinalIgnoreCaseComparisonEqual(String key) => Key.Equals(key, StringComparison.OrdinalIgnoreCase);
    #endregion Private Methods
}

namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct CommandKey : IEquatable<CommandKey>
{
	public String Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandKey"/> struct.
    /// </summary>
    /// <param name="key">The key</param>
	public CommandKey(String key)
	{
		Value = key;
	}

    /// <summary>
    /// Determines whether the <paramref name="other"/> is equal to the current <see cref="CommandKey"/>
    /// </summary>
    /// <param name="other">The other <see cref="CommandKey"/>.</param>
    /// <returns>True if the other <see cref="CommandKey"/> is equal to the current <see cref="CommandKey"/>; otherwise, false.</returns>
	public Boolean Equals(CommandKey other) => String.Equals(Value, other.Value);

    /// <summary>
    /// Determines whether the <paramref name="obj"/> is equal to the current <see cref="Object?"/>
    /// </summary>
    /// <param name="obj">The obj <see cref="Object?"/></param>
    /// <returns>True if the obj <see cref="Object?"/> is equal to the current <see cref="Object?"/>; otherwise, false.</returns>
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandKey other && Equals(other);

    /// <summary>
    /// Gets the hash code for the <see cref="CommandKey"/>.
    /// </summary>
    /// <returns>A hash code for the <see cref="CommandKey"/>.</returns>
	public override Int32 GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Gets the string representation of <see cref="CommandKey"/>.
    /// </summary>
    /// <returns>The string representation of <see cref="CommandKey"/>.</returns>
    public override String ToString() => Value;

    /// <summary>
    /// Defines an implicit conversion of a string to a <see cref="CommandKey"/>.
    /// </summary>
    /// <param name="key">The key to convert to <see cref="CommandKey"/>.</param>
    public static implicit operator CommandKey(String key) => new CommandKey(key);

    /// <summary>
    /// Defines an implicit conversion of a <see cref="CommandKey"/> to a string.
    /// </summary>
    /// <param name="commandKey">The <see cref="CommandKey"/> to convert to string.</param>
    public static implicit operator String(CommandKey commandKey) => commandKey.Value;

    /// <summary>
    /// Determines whether two specified <see cref="CommandKey"/> instances are equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandKey"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandKey"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandKey"/> instances are equal; otherwise, false.</returns>
    public static Boolean operator ==(CommandKey left, CommandKey right) => left.Equals(right);

    /// <summary>
    /// Determines whether two specified <see cref="CommandKey"/> instances are not equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandKey"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandKey"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandKey"/> instances are not equal; otherwise, false.</returns>
    public static Boolean operator !=(CommandKey left, CommandKey right) => !left.Equals(right);

    public Boolean IsByteCountKey() => IsOrdinalIgnoreCaseComparisonEqual("c");
    public Boolean IsCharacterCountKey() => IsOrdinalIgnoreCaseComparisonEqual("m");
    public Boolean IsLineCountKey() => IsOrdinalIgnoreCaseComparisonEqual("l");
    public Boolean IsWordCountKey() => IsOrdinalIgnoreCaseComparisonEqual("w");

    #region Private Methods
    private Boolean IsOrdinalIgnoreCaseComparisonEqual(String key) => Value.Equals(key, StringComparison.OrdinalIgnoreCase);
    #endregion Private Methods
}

namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct Command : IEquatable<Command>
{
	public String Key { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> struct.
    /// </summary>
    /// <param name="key">The key</param>
	public Command(String key)
	{
		Key = key;
	}

    /// <summary>
    /// Determines whether the <paramref name="other"/> is equal to the current <see cref="Command"/>
    /// </summary>
    /// <param name="other">The other <see cref="Command"/>.</param>
    /// <returns>True if the other <see cref="Command"/> is equal to the current <see cref="Command"/>; otherwise, false.</returns>
	public Boolean Equals(Command other) => String.Equals(Key, other.Key);

    /// <summary>
    /// Determines whether the <paramref name="obj"/> is equal to the current <see cref="Object?"/>
    /// </summary>
    /// <param name="obj">The obj <see cref="Object?"/></param>
    /// <returns>True if the obj <see cref="Object?"/> is equal to the current <see cref="Object?"/>; otherwise, false.</returns>
	public override Boolean Equals(Object? obj) => obj is not null && obj is Command other && Equals(other);

    /// <summary>
    /// Gets the hash code for the <see cref="Command"/>.
    /// </summary>
    /// <returns>A hash code for the <see cref="Command"/>.</returns>
	public override Int32 GetHashCode() => Key.GetHashCode();

    /// <summary>
    /// Gets the string representation of <see cref="Command"/>.
    /// </summary>
    /// <returns>The string representation of <see cref="Command"/>.</returns>
    public override String ToString() => Key;

    /// <summary>
    /// Defines an implicit conversion of a string to a <see cref="Command"/>.
    /// </summary>
    /// <param name="key">The key to convert to <see cref="Command"/>.</param>
    public static implicit operator Command(String key) => new Command(key);

    /// <summary>
    /// Defines an implicit conversion of a <see cref="Command"/> to a string.
    /// </summary>
    /// <param name="commandKey">The <see cref="Command"/> to convert to string.</param>
    public static implicit operator String(Command commandKey) => commandKey.Key;

    /// <summary>
    /// Determines whether two specified <see cref="Command"/> instances are equal.
    /// </summary>
    /// <param name="left">The <see cref="Command"/> instance on the left</param>
    /// <param name="right">The <see cref="Command"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="Command"/> instances are equal; otherwise, false.</returns>
    public static Boolean operator ==(Command left, Command right) => left.Equals(right);

    /// <summary>
    /// Determines whether two specified <see cref="Command"/> instances are not equal.
    /// </summary>
    /// <param name="left">The <see cref="Command"/> instance on the left</param>
    /// <param name="right">The <see cref="Command"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="Command"/> instances are not equal; otherwise, false.</returns>
    public static Boolean operator !=(Command left, Command right) => !left.Equals(right);

    public Boolean IsByteCountKey() => IsOrdinalIgnoreCaseComparisonEqual("c");
    public Boolean IsCharacterCountKey() => IsOrdinalIgnoreCaseComparisonEqual("m");
    public Boolean IsLineCountKey() => IsOrdinalIgnoreCaseComparisonEqual("l");
    public Boolean IsWordCountKey() => IsOrdinalIgnoreCaseComparisonEqual("w");

    #region Private Methods
    private Boolean IsOrdinalIgnoreCaseComparisonEqual(String key) => Key.Equals(key, StringComparison.OrdinalIgnoreCase);
    #endregion Private Methods
}

namespace VP.CodingChallenge.WCNet.CommandModels;

internal readonly struct Command : IEquatable<Command>
{
	public String Key { get; }
	public Command(String key)
	{
		Key = key;
	}

	public Boolean Equals(Command other) => String.Equals(Key, other.Key);

	public override Boolean Equals(Object? obj) => obj is not null && obj is Command other && Equals(other);

	public override Int32 GetHashCode() => Key.GetHashCode();

	/// <summary>
	/// Returns the value of the key
	/// </summary>
	/// <returns></returns>
	public override String ToString() => Key;

	/// <summary>
	/// Implicit conversion from String to Command
	/// </summary>
	/// <param name="key"></param>
	public static implicit operator Command(String key) => new Command(key);

	/// <summary>
	/// Implicit conversion from Command to String
	/// </summary>
	/// <param name="command"></param>
	public static implicit operator String(Command command) => command.Key;

	/// <summary>
	/// Operator overload for equality
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static Boolean operator ==(Command left, Command right) => left.Equals(right);

	/// <summary>
	/// Operator overload for inequality
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static Boolean operator !=(Command left, Command right) => !left.Equals(right);
}

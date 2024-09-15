namespace VP.CodingChallenge.WCNet.CommandModels;

/// <summary>
/// Class CommandArgument
/// </summary>
public class CommandArgument : IEquatable<CommandArgument>
{
    /// <summary>
    /// Gets the <see cref="CommandModels.CommandKey"/>
    /// </summary>
    public CommandKey CommandKey { get; }

    /// <summary>
    /// Gets the Filepath
    /// </summary>
	public String Filepath { get; } = String.Empty;

    /// <summary>
    /// Initializes a new instance of <see cref="CommandArgument"/>.
    /// </summary>
    /// <param name="commandKey">The <see cref="CommandModels.CommandKey"/></param>
    /// <param name="filepath">The filepath</param>
    private CommandArgument(CommandKey commandKey, String filepath)
    {
        CommandKey = commandKey;
        Filepath = filepath;
    }

    /// <summary>
    /// Creates a new instance of <see cref="CommandArgument"/>.
    /// </summary>
    /// <param name="CommandKeys">The <see cref="CommandModels.CommandKey"/></param>
    /// <param name="filepath">The filepath</param>
    /// <returns>An instance of <see cref="CommandArgument"/>.</returns>
    public static CommandArgument Create(CommandKey commandKey, String filepath) => new CommandArgument(commandKey, filepath);

    /// <summary>
    /// Determines whether the <paramref name="other"/> (<see cref="CommandArgument"/>) is equal to the current <see cref="CommandArgument"/>.
    /// </summary>
    /// <param name="other">The other <see cref="CommandArgument"/></param>
    /// <returns>True if other (<see cref="CommandArgument"/>) instance is equal to the current <see cref="CommandArgument"/>; otherwise, false.</returns>
	public Boolean Equals(CommandArgument? other) => this == other;

    /// <summary>
    /// Determines whether the <paramref name="obj"/> (<see cref="Object?"/>) is equal to the current instance.
    /// </summary>
    /// <param name="obj">The obj <see cref="Object?"/></param>
    /// <returns>True if obj (<see cref="Object?"/>) instance is equal to the current instance; otherwise, false.</returns>
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandArgument other && Equals(other);

    /// <summary>
    /// Gets the hash code for the <see cref="CommandArgument"/>.
    /// </summary>
    /// <returns>A hash code for the current <see cref="CommandArgument"/>.</returns>
	public override Int32 GetHashCode()
        => HashCode.Combine(CommandKey, Filepath);

    /// <summary>
    /// Gets the string representation of <see cref="CommandArgument"/>.
    /// </summary>
    /// <returns>The string representation of <see cref="CommandArgument"/>.</returns>
	public override String ToString() => $"Command: {CommandKey}, Filename: \"{Path.GetFileName(Filepath)}\"";

    /// <summary>
    /// Determines whether two specified <see cref="CommandArgument"/> instances are equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandArgument"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandArgument"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandArgument"/> instances are equal; otherwise, false.</returns>
	public static Boolean operator ==(CommandArgument? left, CommandArgument? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.CommandKey == right.CommandKey && String.Equals(left.Filepath, right.Filepath, StringComparison.Ordinal);
    }

    /// <summary>
    /// Determines whether two specified <see cref="CommandArgument"/> instances are not equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandArgument"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandArgument"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandArgument"/> instances are not equal; otherwise, false.</returns>
	public static Boolean operator !=(CommandArgument? left, CommandArgument? right) => !(left == right);
}

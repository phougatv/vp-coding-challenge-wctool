namespace VP.CodingChallenge.WCNet.CommandModels;

/// <summary>
/// Class CommandArgument
/// </summary>
public class CommandRequest : IEquatable<CommandRequest>
{
    /// <summary>
    /// Gets the <see cref="Command"/>
    /// </summary>
    public Command CommandKey { get; }

    /// <summary>
    /// Gets the Filepath
    /// </summary>
	public Filepath Filepath { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="CommandRequest"/>.
    /// </summary>
    /// <param name="commandKey">The <see cref="CommandModels.Command"/></param>
    /// <param name="filepath">The filepath</param>
    private CommandRequest(Command commandKey, String filepath)
    {
        CommandKey = commandKey;
        Filepath = filepath;
    }

    /// <summary>
    /// Creates a new instance of <see cref="CommandRequest"/>.
    /// </summary>
    /// <param name="CommandKeys">The <see cref="CommandModels.Command"/></param>
    /// <param name="filepath">The filepath</param>
    /// <returns>An instance of <see cref="CommandRequest"/>.</returns>
    public static CommandRequest Create(Command commandKey, String filepath) => new CommandRequest(commandKey, filepath);

    /// <summary>
    /// Determines whether the <paramref name="other"/> (<see cref="CommandRequest"/>) is equal to the current <see cref="CommandRequest"/>.
    /// </summary>
    /// <param name="other">The other <see cref="CommandRequest"/></param>
    /// <returns>True if other (<see cref="CommandRequest"/>) instance is equal to the current <see cref="CommandRequest"/>; otherwise, false.</returns>
	public Boolean Equals(CommandRequest? other) => this == other;

    /// <summary>
    /// Determines whether the <paramref name="obj"/> (<see cref="Object?"/>) is equal to the current instance.
    /// </summary>
    /// <param name="obj">The obj <see cref="Object?"/></param>
    /// <returns>True if obj (<see cref="Object?"/>) instance is equal to the current instance; otherwise, false.</returns>
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandRequest other && Equals(other);

    /// <summary>
    /// Gets the hash code for the <see cref="CommandRequest"/>.
    /// </summary>
    /// <returns>A hash code for the current <see cref="CommandRequest"/>.</returns>
	public override Int32 GetHashCode()
        => HashCode.Combine(CommandKey, Filepath);

    /// <summary>
    /// Gets the string representation of <see cref="CommandRequest"/>.
    /// </summary>
    /// <returns>The string representation of <see cref="CommandRequest"/>.</returns>
	public override String ToString() => $"Command: {CommandKey}, Filename: \"{Path.GetFileName(Filepath)}\"";

    /// <summary>
    /// Determines whether two specified <see cref="CommandRequest"/> instances are equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandRequest"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandRequest"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandRequest"/> instances are equal; otherwise, false.</returns>
	public static Boolean operator ==(CommandRequest? left, CommandRequest? right)
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
    /// Determines whether two specified <see cref="CommandRequest"/> instances are not equal.
    /// </summary>
    /// <param name="left">The <see cref="CommandRequest"/> instance on the left</param>
    /// <param name="right">The <see cref="CommandRequest"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="CommandRequest"/> instances are not equal; otherwise, false.</returns>
	public static Boolean operator !=(CommandRequest? left, CommandRequest? right) => !(left == right);
}

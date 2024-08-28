namespace VP.CodingChallenge.WCNet.CommandModels;

internal class CommandArgument : IEquatable<CommandArgument>
{
	internal Command Command { get; }
	internal String Filename { get; } = String.Empty;

	private CommandArgument(Command command, String filename)
	{
		Command = command;
		Filename = filename;
	}

	public static CommandArgument Create(Command command, String filename) => new CommandArgument(command, filename);

	public Boolean Equals(CommandArgument? other) => this == other;

	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandArgument other && Equals(other);

	public override Int32 GetHashCode() => HashCode.Combine(Command, Filename);

	public override String ToString() => $"Command: {Command}, Filename: \"{Filename}\"";

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

		return left.Command.Equals(right.Command) && String.Equals(left.Filename, right.Filename);
	}

	public static Boolean operator !=(CommandArgument? left, CommandArgument? right) => !(left == right);
}

namespace VP.CodingChallenge.WCNet.CommandModels;

internal class CommandArgument : IEquatable<CommandArgument>
{
	internal CommandKey CommandKey { get; }
	internal String Filepath { get; } = String.Empty;

	private CommandArgument(CommandKey commandKey, String filepath)
	{
		CommandKey = commandKey;
		Filepath = filepath;
	}

	public static CommandArgument Create(CommandKey commandKey, String filename) => new CommandArgument(commandKey, filename);

	public Boolean Equals(CommandArgument? other) => this == other;

	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandArgument other && Equals(other);

	public override Int32 GetHashCode() => HashCode.Combine(CommandKey, Filepath);

	public override String ToString() => $"Command: {CommandKey}, Filename: \"{Path.GetFileName(Filepath)}\"";

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

		return left.CommandKey.Equals(right.CommandKey) && String.Equals(left.Filepath, right.Filepath);
	}

	public static Boolean operator !=(CommandArgument? left, CommandArgument? right) => !(left == right);
}

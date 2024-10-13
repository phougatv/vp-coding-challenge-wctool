namespace VP.CodingChallenge.WCNet.CommandModels;

public class CommandRequest : IEquatable<CommandRequest>
{
    public CommandKey CommandKey { get; }
    public IReadOnlyList<CommandKey> DefaultCommandKeys { get; }
    public Boolean IsDefault { get; }
	public Filepath Filepath { get; }

    private CommandRequest(
        CommandKey commandKey,
        IReadOnlyList<CommandKey> defaultCommandKeys,
        String filepath,
        Boolean isDefault)
    {
        CommandKey = commandKey;
        DefaultCommandKeys = defaultCommandKeys;
        Filepath = filepath;
        IsDefault = isDefault;
    }

    public static CommandRequest Create(CommandKey command, Filepath filepath)
        => new CommandRequest(command, Array.Empty<CommandKey>(), filepath, false);
    public static CommandRequest CreateDefault(CommandKey[] defaultCommands, Filepath filepath)
        => new CommandRequest(CommandKey.None, defaultCommands, filepath, true);
	public Boolean Equals(CommandRequest? other) => this == other;
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandRequest other && Equals(other);
	public override Int32 GetHashCode() => HashCode.Combine(CommandKey, Filepath);
	public override String ToString() => $"Command: {CommandKey}, Filename: \"{Path.GetFileName(Filepath)}\"";
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
	public static Boolean operator !=(CommandRequest? left, CommandRequest? right) => !(left == right);
}

namespace VP.CodingChallenge.WCNet.CommandModels;

public class CommandRequest : IEquatable<CommandRequest>
{
    public CommandKey CommandKey { get; }
    public IReadOnlyCollection<CommandKey> CommandKeys { get; }
    public Boolean IsDefault { get; }
	public Filepath Filepath { get; }

    private CommandRequest(
        CommandKey commandKey,
        IReadOnlyCollection<CommandKey> defaultCommandKeys,
        String filepath,
        Boolean isDefault)
    {
        CommandKey = commandKey;
        CommandKeys = defaultCommandKeys;
        Filepath = filepath;
        IsDefault = isDefault;
    }

    #region Test
    public static CommandRequest CreateTest(CommandKey commandKey, Filepath filepath)
        => new CommandRequest(CommandKey.None, [commandKey], filepath, false);
    public static CommandRequest CreateTest(CommandKey[] defaultCommandKeys, Filepath filepath)
        => new CommandRequest(CommandKey.None, defaultCommandKeys, filepath, true);
    #endregion Test

    public static CommandRequest Create(CommandKey command, Filepath filepath)
        => new CommandRequest(command, Array.Empty<CommandKey>(), filepath, false);
    public static CommandRequest CreateDefault(CommandKey[] defaultCommands, Filepath filepath)
        => new CommandRequest(CommandKey.None, defaultCommands, filepath, true);
	public Boolean Equals(CommandRequest? other) => this == other;
	public override Boolean Equals(Object? obj) => obj is not null && obj is CommandRequest other && Equals(other);
    public override Int32 GetHashCode()
    {
        var defaultKeysHash = CommandKeys.Aggregate(0, (hash, key) => HashCode.Combine(hash, key));
        return HashCode.Combine(CommandKey, Filepath, IsDefault, defaultKeysHash);
    }
	public override String ToString()
    {
        var filename = Path.GetFileName(Filepath);

        if (IsDefault)
        {
            return $"Default command keys: {String.Join(", ", CommandKeys)}, Filename: \"{filename}\"";
        }

        return $"Command key: {CommandKey}, Filename: \"{filename}\"";
    }
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

        return
            left.CommandKey == right.CommandKey &&
            String.Equals(left.Filepath, right.Filepath, StringComparison.Ordinal) &&
            left.IsDefault == right.IsDefault &&
            Enumerable.SequenceEqual(left.CommandKeys, right.CommandKeys);
    }
	public static Boolean operator !=(CommandRequest? left, CommandRequest? right) => !(left == right);
}

namespace VP.CodingChallenge.WCNet.CommandModels;

public class CommandRequest : IEquatable<CommandRequest>
{
    public IReadOnlyCollection<CommandKey> CommandKeys { get; }
    public Filepath Filepath { get; }

    private CommandRequest(IReadOnlyCollection<CommandKey> defaultCommandKeys, String filepath)
    {
        CommandKeys = defaultCommandKeys;
        Filepath = filepath;
    }

    #region Test
    public static CommandRequest Create(CommandKey commandKey, Filepath filepath)
        => new CommandRequest([commandKey], filepath);
    public static CommandRequest Create(IReadOnlyCollection<CommandKey> defaultCommandKeys, Filepath filepath)
        => new CommandRequest(defaultCommandKeys, filepath);
    #endregion Test

    public Boolean Equals(CommandRequest? other)
        => other is not null
            && String.Equals(Filepath, other.Filepath, StringComparison.Ordinal)
            && Enumerable.SequenceEqual(CommandKeys, other.CommandKeys);
    public override Boolean Equals(Object? obj) => obj is CommandRequest other && Equals(other);
    public override Int32 GetHashCode()
    {
        var defaultKeysHash = CommandKeys.Aggregate(0, (hash, key) => HashCode.Combine(hash, key));
        return HashCode.Combine(Filepath, defaultKeysHash);
    }
    public override String ToString()
    {
        var filename = Path.GetFileName(Filepath);
        return $"{nameof(CommandRequest)}=[CommandKeys: {String.Join(", ", CommandKeys)}, Filename: \"{filename}\"]";
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

        return left.Equals(right);
    }
    public static Boolean operator !=(CommandRequest? left, CommandRequest? right) => !(left == right);
}

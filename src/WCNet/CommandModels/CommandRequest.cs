namespace VP.CodingChallenge.WCNet.CommandModels;

public class CommandRequest : IEquatable<CommandRequest>
{
    public IReadOnlyCollection<CommandKey> CommandKeys { get; }
    public FilePath FilePath { get; }

    private CommandRequest(IReadOnlyCollection<CommandKey> defaultCommandKeys, String filepath)
    {
        CommandKeys = defaultCommandKeys;
        FilePath = filepath;
    }

    #region Test
    public static CommandRequest Create(CommandKey commandKey, FilePath filepath)
        => new CommandRequest([commandKey], filepath);
    public static CommandRequest Create(IReadOnlyCollection<CommandKey> defaultCommandKeys, FilePath filepath)
        => new CommandRequest(defaultCommandKeys, filepath);
    #endregion Test

    public Boolean Equals(CommandRequest? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (CommandKeys is null || other.CommandKeys is null)
        {
            return
                CommandKeys is null
                && other.CommandKeys is null
                && FilePath.Equals(other.FilePath);
        }

        return
            FilePath.Equals(other.FilePath)
            && Enumerable.SequenceEqual(CommandKeys, other.CommandKeys);
    }

    public override Boolean Equals(Object? obj) => obj is CommandRequest other && Equals(other);
    public override Int32 GetHashCode()
    {
        if (CommandKeys is null)
        {
            return HashCode.Combine(FilePath, 0);
        }

        var defaultKeysHash = CommandKeys.Aggregate(0, (hash, key) => HashCode.Combine(hash, key));
        return HashCode.Combine(FilePath, defaultKeysHash);
    }
    public override String ToString()
    {
        var nameof_CommandRequest = nameof(CommandRequest);
        var commandKeys = CommandKeys switch
        {
            null => "null",
            { Count: 0 } => "empty",
            _ => String.Join(", ", CommandKeys.SelectMany(key => key.Key))
        };

        return $"{nameof_CommandRequest}=[CommandKeys: {commandKeys}, FilePath: \"{FilePath.Value}\"]";
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

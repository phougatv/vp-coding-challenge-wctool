namespace VP.CodingChallenge.WCNet.CommandModels;
public readonly struct FilePath : IEquatable<FilePath>
{
    public static readonly FilePath Empty = String.Empty;

    public String Value { get; }

    public FilePath(String path)
    {
        if (String.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Filepath cannot be null or empty or only whitespace.", nameof(path));

        Value = path;
    }

    public String GetFileName() => Path.GetFileName(Value);

    public Boolean Equals(FilePath other) => String.Equals(Value, other.Value);
    public override Boolean Equals(Object? obj) => obj is not null && obj is FilePath other && Equals(other);
    public override Int32 GetHashCode() => Value is null ? 0 : Value.GetHashCode();
    public override String ToString()
    {
        var nameof_FilePath = nameof(FilePath);
        var value = Value switch
        {
            null => "null",
            _ => Value
        };

        return $"{nameof_FilePath}=[Path: \"{value}\"]";
    }
    public static implicit operator FilePath(String value) => new FilePath(value);
    public static implicit operator String(FilePath filepath) => filepath.Value;
    public static Boolean operator ==(FilePath left, FilePath right) => left.Equals(right);
    public static Boolean operator !=(FilePath left, FilePath right) => !left.Equals(right);
}

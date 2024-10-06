namespace VP.CodingChallenge.WCNet.CommandModels;
public readonly struct Filepath : IEquatable<Filepath>
{
    public static readonly Filepath Empty = String.Empty;

    public String Value { get; }

    public Filepath(String value)
    {
        Value = value;
    }

    public String GetFilename() => Path.GetFileName(Value);

    public Boolean Equals(Filepath other) => String.Equals(Value, other.Value);
    public override Boolean Equals(Object? obj) => obj is not null && obj is Filepath other && Equals(other);
    public override Int32 GetHashCode() => Value.GetHashCode();
    public override String ToString() => Value;
    public static implicit operator Filepath(String value) => new Filepath(value);
    public static implicit operator String(Filepath filepath) => filepath.Value;
    public static Boolean operator ==(Filepath left, Filepath right) => left.Equals(right);
    public static Boolean operator !=(Filepath left, Filepath right) => !left.Equals(right);
}

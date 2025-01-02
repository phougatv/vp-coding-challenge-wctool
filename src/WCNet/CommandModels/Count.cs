[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.UnitTests")]
namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct Count(Int64 value) : IEquatable<Count>
{
    public Int64 Value { get; } = value;

    public Boolean Equals(Count other) => Value == other.Value;

    public override Boolean Equals(Object? obj) => obj is not null && obj is Count other && Equals(other);

    public override Int32 GetHashCode() => HashCode.Combine(Value);

    public override String ToString() => $"Count=[Value: \"{Value}\"]";

    public static implicit operator Int64(Count count) => count.Value;

    public static implicit operator Count(Int64 value) => new(value);

    public static implicit operator Count(Int32 value) => new(value);

    public static implicit operator Count(Int16 value) => new(value);

    public static implicit operator Count(Byte value) => new(value);

    public static Boolean operator ==(Count left, Count right) => left.Equals(right);

    public static Boolean operator !=(Count left, Count right) => !(left == right);
}

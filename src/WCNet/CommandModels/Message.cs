namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct Message : IEquatable<Message>
{
    public String Text { get; }

    public Message(String text)
    {
        Text = text;
    }

    public Boolean Equals(Message other) => String.Equals(Text, other.Text);
    public override Boolean Equals(Object? obj) => obj is not null && obj is Message other && Equals(other);
    public override Int32 GetHashCode() => Text.GetHashCode();
    public override String ToString() => Text;
    public static implicit operator Message(String text) => new Message(text);
    public static implicit operator Message(StringBuilder builder) => new Message(builder.ToString());
    public static implicit operator String(Message message) => message.Text;
    public static Boolean operator ==(Message left, Message right) => left.Equals(right);
    public static Boolean operator !=(Message left, Message right) => !left.Equals(right);
}

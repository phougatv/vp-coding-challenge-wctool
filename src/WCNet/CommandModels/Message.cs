namespace VP.CodingChallenge.WCNet.CommandModels;

public readonly struct Message : IEquatable<Message>
{
    public String Text { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Message"/> struct.
    /// </summary>
    /// <param name="text">The text</param>
    public Message(String text)
    {
        Text = text;
    }

    /// <summary>
    /// Determines whether the <paramref name="other"/> is equal to the current <see cref="Message"/>
    /// </summary>
    /// <param name="other">The other <see cref="Message"/>.</param>
    /// <returns>True if the other <see cref="Message"/> is equal to the current <see cref="Message"/>; otherwise, false.</returns>
    public Boolean Equals(Message other) => String.Equals(Text, other.Text);

    /// <summary>
    /// Determines whether the specified <paramref name="obj"/> is equal to the current <see cref="Object?"/>
    /// </summary>
    /// <param name="obj">The obj <see cref="Object?"/></param>
    /// <returns>True if the specified obj <see cref="Object?"/> is equal to the current <see cref="Object?"/>; otherwise, false.</returns>
    public override Boolean Equals(Object? obj) => obj is not null && obj is Message other && Equals(other);

    /// <summary>
    /// Gets the hash code for the <see cref="Message"/>.
    /// </summary>
    /// <returns>A hash code for the <see cref="Message"/>.</returns>
    public override Int32 GetHashCode() => Text.GetHashCode();

    /// <summary>
    /// Gets the string representation of <see cref="Message"/>.
    /// </summary>
    /// <returns>The string representation of <see cref="Message"/>.</returns>
    public override String ToString() => Text;

    /// <summary>
    /// Defines an implicit conversion of a string to a <see cref="Message"/>.
    /// </summary>
    /// <param name="text">The string text to convert</param>
    public static implicit operator Message(String text) => new Message(text);

    /// <summary>
    /// Defines an implicit conversion of a <see cref="Message"/> to a string.
    /// </summary>
    /// <param name="message">The <see cref="Message"/> to convert to a string.</param>
    public static implicit operator String(Message message) => message.Text;

    /// <summary>
    /// Determines whether two specified <see cref="Message"/> instances are equal.
    /// </summary>
    /// <param name="left">The <see cref="Message"/> instance on the left</param>
    /// <param name="right">The <see cref="Message"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="Message"/> instances are equal; otherwise, false.</returns>
    public static Boolean operator ==(Message left, Message right) => left.Equals(right);

    /// <summary>
    /// Determines whether two specified <see cref="Message"/> instances are not equal.
    /// </summary>
    /// <param name="left">The <see cref="Message"/> instance on the left</param>
    /// <param name="right">The <see cref="Message"/> instance on the right</param>
    /// <returns>True if the two specified <see cref="Message"/> instances are not equal; otherwise, true.</returns>
    public static Boolean operator !=(Message left, Message right) => !left.Equals(right);
}

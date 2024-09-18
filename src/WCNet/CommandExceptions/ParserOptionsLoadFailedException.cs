namespace VP.CodingChallenge.WCNet.CommandExceptions;

public class ParserOptionsLoadFailedException : Exception
{
    public ParserOptionsLoadFailedException()
        : base($"Failed to parse the {nameof(ParserOptions)}") { }

    public ParserOptionsLoadFailedException(String message)
        : base(message) { }

    public ParserOptionsLoadFailedException(String message, Exception innerException)
        : base(message, innerException) { }
}

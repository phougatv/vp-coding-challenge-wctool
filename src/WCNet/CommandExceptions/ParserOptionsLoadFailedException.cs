namespace VP.CodingChallenge.WCNet.CommandExceptions;

public class ParserOptionsLoadFailedException : Exception
{
    public ParserOptionsLoadFailedException()
        : base($"Failed to parse the {nameof(ParseOptions)}") { }

    public ParserOptionsLoadFailedException(String message)
        : base(message) { }
}

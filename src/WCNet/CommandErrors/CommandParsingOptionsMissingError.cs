namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandParsingOptionsMissingError : Error
{
    private readonly String _message;

    private CommandParsingOptionsMissingError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static CommandParsingOptionsMissingError Create()
        => new CommandParsingOptionsMissingError("CommandParsingOptions and its required properties cannot be null or empty.");

    public override String ToString() => _message;
}

namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandRequestNullError : Error
{
    private readonly String _message;

    private CommandRequestNullError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static CommandRequestNullError Create() => new CommandRequestNullError("'CommandRequest' instance cannot be null.");

    public override String ToString() => _message;
}

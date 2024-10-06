namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandNotSetError : Error
{
    private readonly String _message;

    private CommandNotSetError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static CommandNotSetError Create() => new CommandNotSetError($"Command is not set. First set command and try again.");

    public override String ToString() => _message;
}

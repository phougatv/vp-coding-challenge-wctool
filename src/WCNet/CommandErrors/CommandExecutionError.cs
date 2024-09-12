namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandExecutionError : Error
{
    private readonly String _message;

    private CommandExecutionError(String message)
        : base(message)
    {
        _message = message;
    }

    public static CommandExecutionError Create(String commandKey)
        => new CommandExecutionError($"Error executing command: {commandKey}.");

    public static CommandExecutionError Create(String commandKey, Exception exception)
        => new CommandExecutionError($"Error executing command: {commandKey}: {exception.Message}.");

    public override String ToString() => _message;
}

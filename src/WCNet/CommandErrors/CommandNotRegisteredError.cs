namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandNotRegisteredError : Error
{
    private readonly String _message;

    private CommandNotRegisteredError(String message)
		: base(message)
	{
        _message = message;
	}

	internal static CommandNotRegisteredError Create(String key)
		=> new CommandNotRegisteredError($"No corresponding command is registered for CommandKey: '{key}'.");

    public override String ToString() => _message;
}

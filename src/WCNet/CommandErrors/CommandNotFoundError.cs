namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandNotFoundError : Error
{
    private readonly String _message;

    private CommandNotFoundError(String message)
		: base(message)
	{
        _message = message;
	}

    internal static CommandNotFoundError Create()
        => new CommandNotFoundError($"Command not found.");

<<<<<<< HEAD
	internal static CommandNotFoundError Create(Command command)
=======
	internal static CommandNotFoundError Create(CommandKey command)
>>>>>>> master
		=> new CommandNotFoundError($"Command: \"{command}\" not found.");

    public override String ToString() => _message;
}

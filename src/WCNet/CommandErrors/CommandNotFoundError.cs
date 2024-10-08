﻿namespace VP.CodingChallenge.WCNet.CommandErrors;

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

	internal static CommandNotFoundError Create(Command command)
		=> new CommandNotFoundError($"Command: \"{command}\" not found.");

    public override String ToString() => _message;
}

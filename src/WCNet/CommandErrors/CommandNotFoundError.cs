﻿namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandNotFoundError : Error
{
	private CommandNotFoundError(String message)
		: base(message)
	{

	}

	internal static CommandNotFoundError Create(CommandKey command)
		=> new CommandNotFoundError($"Command: {command} not found.");
}

namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandFormatError : Error
{
	private CommandFormatError(String message)
		: base(message)
	{

	}

	internal static CommandFormatError Create()
		=> new CommandFormatError("Incorrect command format, try -<command> <filepath_along_with_filename.extension>.");
}

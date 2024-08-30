namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandFormatError : Error
{
    private readonly String _message;

	private CommandFormatError(String message)
		: base(message)
	{
        _message = message;
	}

	internal static CommandFormatError Create()
		=> new CommandFormatError("Incorrect command format, try -<command> <filepath_along_with_filename.extension>.");

    public override String ToString() => _message;
}

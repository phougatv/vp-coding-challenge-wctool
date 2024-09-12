namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FileNotFoundError : Error
{
    private readonly String _message;

    private FileNotFoundError(String message)
		: base(message)
	{
        _message = message;
	}

	internal static FileNotFoundError Create(String filename)
		=> new FileNotFoundError($"File: {filename}, not found.");

    public override String ToString() => _message;
}

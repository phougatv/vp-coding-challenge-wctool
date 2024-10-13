namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FileExtensionNotAllowedError : Error
{
    private readonly String _message;

    private FileExtensionNotAllowedError(String message)
		: base(message)
	{
        _message = message;
	}

	internal static FileExtensionNotAllowedError Create(String fileExtension)
		=> new FileExtensionNotAllowedError($"File extension: \".{fileExtension}\" not allowed.");

    public override String ToString() => _message;
}

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
    {
        var errorMessage = $"File extension: \"{fileExtension}\" not allowed, file path with correct extension is expected.";
        return new FileExtensionNotAllowedError(errorMessage);
    }

    public override String ToString() => _message;
}

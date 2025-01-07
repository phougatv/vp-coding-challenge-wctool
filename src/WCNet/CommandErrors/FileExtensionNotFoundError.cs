namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FileExtensionNotFoundError : Error
{
    private readonly String _message;

    private FileExtensionNotFoundError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static FileExtensionNotFoundError Create()
        => new FileExtensionNotFoundError("File extension not found, file name with an extension is expected.");

    public override String ToString() => _message;
}

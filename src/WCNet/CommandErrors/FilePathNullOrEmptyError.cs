namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class FilePathNullOrEmptyError : Error
{
    private readonly String _message;

    private FilePathNullOrEmptyError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static FilePathNullOrEmptyError Create() => new FilePathNullOrEmptyError($"'FilePath' cannot be null or empty.");

    public override String ToString() => _message;
}

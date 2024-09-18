namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class ParserOptionsMissingError : Error
{
    private readonly String _message;

    private ParserOptionsMissingError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static ParserOptionsMissingError Create()
        => new ParserOptionsMissingError($"Either ParserOptions object is null or one of its properties is null/empty.");

    public override String ToString() => _message;
}

namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class ParserCommandKeyNotAllowedError : Error
{
    private readonly String _message;

    private ParserCommandKeyNotAllowedError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static ParserCommandKeyNotAllowedError Create(String commandKey)
        => new ParserCommandKeyNotAllowedError($"Command key: '{commandKey}' is not allowed.");

    public override String ToString() => _message;
}

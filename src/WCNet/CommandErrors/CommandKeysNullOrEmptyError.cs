[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.UnitTest")]
namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class CommandKeysNullOrEmptyError : Error
{
    private readonly String _message;

    private CommandKeysNullOrEmptyError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static CommandKeysNullOrEmptyError Create() => new CommandKeysNullOrEmptyError("'CommandKeys' cannot be null or empty.");

    public override String ToString() => _message;
}

namespace VP.CodingChallenge.WCNet.CommandErrors;

internal class InvokerCommandsNullOrEmptyError : Error
{
    private readonly String _message;

    private InvokerCommandsNullOrEmptyError(String message)
        : base(message)
    {
        _message = message;
    }

    internal static InvokerCommandsNullOrEmptyError Create()
        => new InvokerCommandsNullOrEmptyError("Invoker commands is null or empty.");

    public override String ToString() => _message;
}

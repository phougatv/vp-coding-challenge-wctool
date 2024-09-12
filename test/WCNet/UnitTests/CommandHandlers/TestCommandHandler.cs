namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandHandlers;

internal class TestCommandHandler : CommandHandlerBase
{
    private readonly Func<String[], Result<CommandArgument>> _preHandle;
    private readonly Func<CommandArgument, Result<Message>> _handle;
    private readonly Func<Message, Result> _postHandle;

    public TestCommandHandler(
        Func<String[], Result<CommandArgument>> preHandle,
        Func<CommandArgument, Result<Message>> handle,
        Func<Message, Result> postHandle)
    {
        _preHandle = preHandle;
        _handle = handle;
        _postHandle = postHandle;
    }

    protected override Result<Message> Handle(CommandArgument commandArgument) => _handle(commandArgument);
    protected override Result PostHandle(Message message) => _postHandle(message);
    protected override Result<CommandArgument> PreHandle(String[] args) => _preHandle(args);
}

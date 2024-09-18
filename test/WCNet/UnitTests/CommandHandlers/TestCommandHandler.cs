namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandHandlers;

internal class TestCommandHandler : CommandHandlerBase
{
<<<<<<< HEAD
    private readonly Func<String[], Result<CommandRequest>> _preHandle;
    private readonly Func<CommandRequest, Result<Message>> _handle;
    private readonly Func<Message, Result> _postHandle;

    public TestCommandHandler(
        Func<String[], Result<CommandRequest>> preHandle,
        Func<CommandRequest, Result<Message>> handle,
=======
    private readonly Func<String[], Result<CommandArgument>> _preHandle;
    private readonly Func<CommandArgument, Result<Message>> _handle;
    private readonly Func<Message, Result> _postHandle;

    public TestCommandHandler(
        Func<String[], Result<CommandArgument>> preHandle,
        Func<CommandArgument, Result<Message>> handle,
>>>>>>> master
        Func<Message, Result> postHandle)
    {
        _preHandle = preHandle;
        _handle = handle;
        _postHandle = postHandle;
    }

<<<<<<< HEAD
    protected override Result<Message> Handle(CommandRequest commandArgument) => _handle(commandArgument);
    protected override Result PostHandle(Message message) => _postHandle(message);
    //protected override Result<CommandArgument> PreHandle(String[] args) => _preHandle(args);
=======
    protected override Result<Message> Handle(CommandArgument commandArgument) => _handle(commandArgument);
    protected override Result PostHandle(Message message) => _postHandle(message);
    protected override Result<CommandArgument> PreHandle(String[] args) => _preHandle(args);
>>>>>>> master
}

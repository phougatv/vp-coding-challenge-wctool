namespace VP.CodingChallenge.WCNet.Test.UnitTests.CommandHandlers;

using VP.CodingChallenge.WCNet.Sinks;

internal class TestCommandHandler : CommandHandlerBase
{
    private readonly IOutput _output;

    private readonly Func<String[], Result<CommandRequest>> _preHandle;
    private readonly Func<CommandRequest, Result<Message>> _handle;
    //private readonly Func<Message, Result> _postHandle;

    public TestCommandHandler(
        Func<String[], Result<CommandRequest>> preHandle,
        Func<CommandRequest, Result<Message>> handle,
        IOutput output)
        : base(output)
    {
        _preHandle = preHandle;
        _handle = handle;
        //_postHandle = postHandle;
    }

    protected override Result<Message> Handle(CommandRequest commandArgument) => _handle(commandArgument);
    //protected override void PostHandle(Message message) => _postHandle(message);
    //protected override Result<CommandArgument> PreHandle(String[] args) => _preHandle(args);
}

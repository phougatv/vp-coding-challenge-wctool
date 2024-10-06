namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class UserCommandHandler : CommandHandlerBase
{
    private readonly ICommandFactory _commandFactory;
    private readonly ICommandInvoker _commandInvoker;
    private readonly IOutput _output;

    public UserCommandHandler(ICommandFactory commandFactory, ICommandInvoker commandInvoker, IOutput output)
    {
        _commandFactory = commandFactory;
        _commandInvoker = commandInvoker;
        _output = output;
    }

    protected override Result<Message> Handle(CommandRequest request)
    {
        var command = _commandFactory.CreateCommand(request);
        _commandInvoker.SetCommand(command);
        
        var countResult = _commandInvoker.InvokeCommand();
        return GetMessage(countResult, request.Filepath.GetFilename());
    }

    protected override void PostHandle(Message message) => _output.Sink(message);

    private static Result<Message> GetMessage(Result<Count> countResult, String filename)
    {
        if (countResult.IsFailed)
        {
            return Result<Message>.Fail(countResult.Error);
        }

        var textToDisplay = $"{countResult.Value} {filename}";
        return Result<Message>.Ok(textToDisplay);
    }
}

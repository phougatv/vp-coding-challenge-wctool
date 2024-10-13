namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class UserCommandHandler : CommandHandlerBase
{
    private readonly ICommandFactory _factory;
    private readonly ICommandInvoker _invoker;

    public UserCommandHandler(ICommandFactory commandFactory, ICommandInvoker commandInvoker, IOutput output)
        : base(output)
    {
        _factory = commandFactory;
        _invoker = commandInvoker;
    }

    protected override Result<Message> Handle(CommandRequest request)
    {
        var command = _factory.CreateCommand(request.CommandKey);
        _invoker.SetCommand(command);
        
        var countResult = _invoker.InvokeCommand();
        return GetMessage(countResult, request.Filepath.GetFilename());
    }

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

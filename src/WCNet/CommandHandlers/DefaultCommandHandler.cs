namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandFactory _countCommandFactory;
    private readonly ICommandInvoker _invoker;
    private readonly IOutput _output;

    public DefaultCommandHandler(ICommandFactory countCommandFactory, ICommandInvoker invoker, IOutput output)
	{
		_countCommandFactory = countCommandFactory;
        _invoker = invoker;
        _output = output;
	}

    protected override Result<Message> Handle(CommandRequest request)
	{
        var commands = _countCommandFactory.CreateCommands(request);
        _invoker.SetCommands(commands);
        
        var countsResult = _invoker.InvokeCommands();
        var messageResult = GetMessage(countsResult, request.Filepath.GetFilename());

        return messageResult;
	}

    protected override void PostHandle(Message message) => _output.Sink(message);

    private static Result<Message> GetMessage(Result<ICollection<Count>> countsResult, String filename)
    {
        if (countsResult.IsFailed)
        {
            return Result<Message>.Fail(countsResult.Error);
        }

        var builder = new StringBuilder(countsResult.Value.Count);
        foreach (var count in countsResult.Value)
        {
            builder.Append(count);
            builder.Append(' ');
        }

        builder.Append(filename);
        return Result<Message>.Ok(builder);
    }
}

namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class DefaultCommandHandler : CommandHandlerBase
{
    private readonly ICommandFactory _countCommandFactory;
    private readonly ICommandInvoker _invoker;

    public DefaultCommandHandler(ICommandFactory countCommandFactory, ICommandInvoker invoker, IOutput output)
        : base(output)
	{
		_countCommandFactory = countCommandFactory;
        _invoker = invoker;
	}

    protected override Result<Message> Handle(CommandRequest request)
	{
        var commands = _countCommandFactory.CreateCommands(request.DefaultCommandKeys);
        _invoker.SetCommands(commands);
        
        var countsResult = _invoker.InvokeCommands();
        var messageResult = GetMessage(countsResult, request.Filepath.GetFilename());

        return messageResult;
	}

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

namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class AsyncCommandsHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
    : AsyncCommandHandlerBase(output)
{
    protected override async Task<ICollection<Result<Message>>> Handle(CommandRequest commandRequest)
    {
        var commandKeyCount = commandRequest.CommandKeys.Count;
        var commands = CreateCommands(commandRequest, commandKeyCount);
        var messageResults = CreateMessages(commandKeyCount);

        foreach (var command in commands)
        {
            var countResult = await InvokeCommandAsync(command);
            messageResults.Add(GetMessage(countResult, commandRequest.Filepath.GetFilename()));
        }

        return messageResults;
    }

    private static List<Result<Message>> CreateMessages(Int32 commandKeyCount) => new List<Result<Message>>(commandKeyCount);

    private static Result<Message> GetMessage(Result<Count> countResult, String filename)
    {
        if (countResult.IsFailed)
        {
            return Result<Message>.Fail(countResult.Error);
        }

        var textToDisplay = $"{countResult.Value} {filename}";
        return Result<Message>.Ok(textToDisplay);
    }

    private async Task<Result<Count>> InvokeCommandAsync(IAsyncCommand command)
    {
        invoker.SetCommand(command);
        
        var countResult = await invoker.InvokeCommandAsync();
        return countResult;
    }

    private List<IAsyncCommand> CreateCommands(CommandRequest request, Int32 commandKeyCount)
    {
        var commands = new List<IAsyncCommand>(commandKeyCount);
        foreach (var commandKey in request.CommandKeys)
        {
            commands.Add(factory.CreateCommand(commandKey));
        }

        return commands;
    }
}

namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class AsyncCommandsHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
    : AsyncCommandHandlerBase(output)
{
    protected override async Task<Result<ICollection<Message>>> Handle(CommandRequest commandRequest)
    {
        var keyCount = commandRequest.CommandKeys.Count;
        var commands = CreateCommands(commandRequest, keyCount);
        var countResults = await InvokeCommandsAsync(commands);
        var messageResults = CreateMessages(countResults, commandRequest);

        return messageResults;
    }

    private static Result<ICollection<Message>> CreateMessages(Result<ICollection<Result<Count>>> countResults, CommandRequest request)
    {
        if (countResults.IsFailed)
        {
            return Result<ICollection<Message>>.Fail(countResults.Error);
        }

        var messages = new List<Message>(countResults.Value.Count);
        var filename = Path.GetFileName(request.Filepath);
        foreach (var countResult in countResults.Value)
        {
            var message = CreateMessage(countResult, filename);
            messages.Add(message);
        }

        return Result<ICollection<Message>>.Ok(messages);
    }

    private static Message CreateMessage(Result<Count> countResult, String filename)
    {
        if (countResult.IsFailed)
        {
            return countResult.Error.Message;
        }

        return $"{countResult.Value} {filename}";
    }

    private async Task<Result<ICollection<Result<Count>>>> InvokeCommandsAsync(List<IAsyncCommand> commands)
    {
        invoker.SetCommands(commands);

        var countResults = await invoker.InvokeCommandsAsync();
        return countResults;
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

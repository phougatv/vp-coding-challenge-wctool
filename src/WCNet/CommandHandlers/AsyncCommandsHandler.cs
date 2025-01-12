[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.UnitTest")]
namespace VP.CodingChallenge.WCNet.CommandHandlers;

internal class AsyncCommandsHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
    : AsyncCommandHandlerBase(output)
{
    protected override async Task<Result<ICollection<Message>>> Handle(CommandRequest commandRequest)
    {
        if (commandRequest is null)
        {
            return Result<ICollection<Message>>.Fail(CommandRequestNullError.Create());
        }

        var commandResults = CreateCommands(commandRequest);
        if (commandResults.IsFailed)
        {
            return Result<ICollection<Message>>.Fail(commandResults.Error);
        }

        var countResults = await InvokeCommandsAsync(commandResults.Value);
        var messageResults = CreateMessages(commandRequest, countResults);
        return messageResults;
    }

    private Result<ICollection<IAsyncCommand>> CreateCommands(CommandRequest request)
    {
        var commands = factory.CreateCommands(request.CommandKeys);
        return commands;
    }

    private async Task<Result<ICollection<Result<Count>>>> InvokeCommandsAsync(ICollection<IAsyncCommand> commands)
    {
        invoker.SetCommands(commands);

        var countResults = await invoker.InvokeCommandsAsync();
        return countResults;
    }

    private static Result<ICollection<Message>> CreateMessages(CommandRequest request, Result<ICollection<Result<Count>>> countResultsResult)
    {
        if (countResultsResult.IsFailed)
        {
            return Result<ICollection<Message>>.Fail(countResultsResult.Error);
        }

        var countResults = countResultsResult.Value;
        var messages = new List<Message>(countResults.Count);
        var filename = Path.GetFileName(request.FilePath);
        foreach (var countResult in countResults)
        {
            var message = CreateMessage(countResult, filename);
            messages.Add(message);
        }

        return Result<ICollection<Message>>.Ok(messages);
    }

    private static Message CreateMessage(Result<Count> countResult, String filename)
        => countResult.IsFailed ? new Message(countResult.Error.Message) : new Message($"{countResult.Value.Value} {filename}");
}

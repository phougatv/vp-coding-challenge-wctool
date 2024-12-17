//namespace VP.CodingChallenge.WCNet.CommandHandlers;

//internal class AsyncDefaultCommandHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
//    : AsyncCommandHandlerBase(output)
//{
//    private readonly ICommandFactory _factory = factory;
//    private readonly IAsyncCommandInvoker _invoker = invoker;

//    protected override async Task<Result<Message>> Handle(CommandRequest commandRequest)
//    {
//        var commands = _factory.CreateCommands(commandRequest.CommandKeys);
//        _invoker.SetCommands(commands);

//        var countResults = await _invoker.InvokeCommandsAsync();
//        return GetMessage(countResults, commandRequest.Filepath.GetFilename());
//    }

//    private static Result<Message> GetMessage(Result<ICollection<Count>> countsResult, String filename)
//    {
//        if (countsResult.IsFailed)
//        {
//            return Result<Message>.Fail(countsResult.Error);
//        }

//        var builder = new StringBuilder(countsResult.Value.Count);
//        foreach (var count in countsResult.Value)
//        {
//            builder.Append(count);
//            builder.Append(' ');
//        }

//        builder.Append(filename);
//        return Result<Message>.Ok(builder.ToString());
//    }
//}

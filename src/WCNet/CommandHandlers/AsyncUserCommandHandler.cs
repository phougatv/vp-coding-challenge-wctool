//namespace VP.CodingChallenge.WCNet.CommandHandlers;

//internal class AsyncUserCommandHandler(ICommandFactory factory, IAsyncCommandInvoker invoker, IOutput output)
//    : AsyncCommandHandlerBase(output)
//{
//    private readonly ICommandFactory _factory = factory;
//    private readonly IAsyncCommandInvoker _invoker = invoker;

//    protected override async Task<Result<Message>> Handle(CommandRequest commandRequest)
//    {
//        var command = _factory.CreateCommand(commandRequest.CommandKey);
//        _invoker.SetCommand(command);

//        var countResult = await _invoker.InvokeCommandAsync();
//        return GetMessage(countResult, commandRequest.Filepath.GetFilename());
//    }

//    private static Result<Message> GetMessage(Result<Count> countResult, String filename)
//    {
//        if (countResult.IsFailed)
//        {
//            return Result<Message>.Fail(countResult.Error);
//        }

//        var textToDisplay = $"{countResult.Value} {filename}";
//        return Result<Message>.Ok(textToDisplay);
//    }
//}

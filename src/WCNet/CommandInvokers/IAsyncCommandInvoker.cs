namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface IAsyncCommandInvoker
{
    void SetCommand(IAsyncCommand command);
    void SetCommands(ICollection<IAsyncCommand> commands);
    Task<Result<Count>> InvokeCommandAsync();
    Task<Result<ICollection<Count>>> InvokeCommandsAsync();
}

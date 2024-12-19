namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface IAsyncCommandInvoker
{
    void SetCommands(ICollection<IAsyncCommand> commands);
    Task<Result<ICollection<Result<Count>>>> InvokeCommandsAsync();
}

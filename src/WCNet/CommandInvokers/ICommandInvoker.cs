namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface ICommandInvoker
{
    void SetCommand(ICommand command);
    void SetCommands(ICollection<ICommand> commands);
    Result<Count> InvokeCommand();
    Result<ICollection<Count>> InvokeCommands();
}

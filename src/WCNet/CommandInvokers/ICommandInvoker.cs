namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal interface ICommandInvoker
{
    void SetCommand(ICommand command);
    Result<Count> InvokeCommand();
}

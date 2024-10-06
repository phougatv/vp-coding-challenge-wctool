namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class DefaultCommandInvoker : ICommandInvoker
{
    private ICommand? _command = null;

    public Result<Count> InvokeCommand()
    {
        if (_command == null)
        {
            Result<Count>.Fail(CommandNotSetError.Create());
        }

        return _command.Execute();
    }
    public void SetCommand(ICommand command) => _command = command;
}

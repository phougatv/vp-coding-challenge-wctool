namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class DefaultCommandInvoker : ICommandInvoker
{
    private ICommand? _command = null;

    public void InvokeCommand()
    {
        if (_command == null)
        {
            throw new CommandNotSetException();
        }

        _command.Execute();
    }
    public void SetCommand(ICommand command) => _command = command;
}

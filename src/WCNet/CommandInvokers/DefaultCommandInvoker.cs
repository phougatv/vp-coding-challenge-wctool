namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class DefaultCommandInvoker : ICommandInvoker
{
    private ICommand _command = new CommandNotFound();

    public Result<UInt64> InvokeCommand()
    {
        if (_command == null)
        {
            return Result<UInt64>.Fail("Failed to invoke command as it is not set.");
        }

        return _command.Execute();
    }
    public void SetCommand(ICommand command) => _command = command;
}

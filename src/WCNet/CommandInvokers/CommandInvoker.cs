namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class CommandInvoker : ICommandInvoker
{
    private ICommand? _command = null;
    private ICollection<ICommand> _commands = Array.Empty<ICommand>();

    public Result<Count> InvokeCommand()
    {
        if (_command == null)
        {
            return Result<Count>.Fail(CommandNotSetError.Create());
        }

        return _command.Execute();
    }

    public Result<ICollection<Count>> InvokeCommands()
    {
        if (_commands.Count == 0)
        {
            return Result<ICollection<Count>>.Fail(CommandNotSetError.Create());
        }

        var counts = new List<Count>(_commands.Count);
        foreach (var command in _commands)
        {
            var countResult = command.Execute();
            counts.Add(countResult.Value);
        }

        return Result<ICollection<Count>>.Ok(counts);
    }

    public void SetCommand(ICommand command) => _command = command;

    public void SetCommands(ICollection<ICommand> commands) => _commands = commands;
}

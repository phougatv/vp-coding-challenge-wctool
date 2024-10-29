namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class AsyncCommandInvoker : IAsyncCommandInvoker
{
    private IAsyncCommand? _command = null;
    private ICollection<IAsyncCommand> _commands = Array.Empty<IAsyncCommand>();

    public async Task<Result<Count>> InvokeCommandAsync()
    {
        if (_command is null)
        {
            return Result<Count>.Fail(CommandNotSetError.Create());
        }

        return await _command.ExecuteAsync();
    }
    public async Task<Result<ICollection<Count>>> InvokeCommandsAsync()
    {
        if (_commands.Count == 0)
        {
            return Result<ICollection<Count>>.Fail(CommandNotSetError.Create());
        }

        var commandCounts = new List<Count>(_commands.Count);
        foreach (var command in _commands)
        {
            var countResult = await command.ExecuteAsync();
            commandCounts.Add(countResult.Value);
        }

        return Result<ICollection<Count>>.Ok(commandCounts);
    }

    public void SetCommand(IAsyncCommand command) => _command = command;

    public void SetCommands(ICollection<IAsyncCommand> commands) => _commands = commands;
}

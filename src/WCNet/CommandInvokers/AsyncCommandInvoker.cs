namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class AsyncCommandInvoker : IAsyncCommandInvoker
{
    private ICollection<IAsyncCommand> _commands = Array.Empty<IAsyncCommand>();

    public async Task<Result<ICollection<Result<Count>>>> InvokeCommandsAsync()
    {
        if (IsCommandsInvalid())
        {
            return Result<ICollection<Result<Count>>>.Fail("No command found. Use 'SetCommands' method.");
        }

        var commandCounts = new List<Result<Count>>(_commands.Count);
        foreach (var command in _commands)
        {
            var countResult = await command.ExecuteAsync();
            commandCounts.Add(countResult);
        }

        return Result<ICollection<Result<Count>>>.Ok(commandCounts);
    }

    public void SetCommands(ICollection<IAsyncCommand> commands) => _commands = commands;

    private Boolean IsCommandsInvalid() => _commands is null || _commands.Count == 0;
}

[assembly: InternalsVisibleTo("VP.CodingChallenge.WCNet.Tests")]
namespace VP.CodingChallenge.WCNet.CommandInvokers;

internal class CommandInvoker /*: ICommandInvoker, ICommandsInvoker*/
{
    private IAsyncCommand? _command;
    private ICollection<IAsyncCommand> _commands;

    public CommandInvoker()
    {
        _command = null;
        _commands = Array.Empty<IAsyncCommand>();
    }

    //public Result<Count> InvokeCommand()
    //{
    //    if (_command == null)
    //    {
    //        return Result<Count>.Fail(CommandNotSetError.Create());
    //    }

    //    return _command.ExecuteAsync();
    //}

    //public Result<ICollection<Count>> InvokeCommands()
    //{
    //    if (_commands.Count == 0)
    //    {
    //        return Result<ICollection<Count>>.Fail(CommandNotSetError.Create());
    //    }

    //    var counts = new List<Count>(_commands.Count);
    //    foreach (var command in _commands)
    //    {
    //        var countResult = command.ExecuteAsync();
    //        counts.Add(countResult.Value);
    //    }

    //    return Result<ICollection<Count>>.Ok(counts);
    //}

    public void SetCommand(IAsyncCommand command) => _command = command;

    public void SetCommands(ICollection<IAsyncCommand> commands) => _commands = commands;
}
